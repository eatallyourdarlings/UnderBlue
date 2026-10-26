/*
Please donate to support us: https://ciihuy.com/supportus/?lang=en
______ ____  ____  __  __ __  ____  __
  / ____//  _/ /  _/ / / / // / / /\ \/ /
 / /     / /   / /  / /_/ // / / /  \  / 
/ /___ _/ /  _/ /  / __  // /_/ /   / /  
\____//___/ /___/ /_/ /_/ \____/   /_/
*/

using System.Collections.Generic;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteAlways]
public class PowerPoleWiringSystem : MonoBehaviour
{
    [System.Serializable]
    public class WireSet
    {
        public string name = "WireSet";
        public List<Transform> points = new List<Transform>();
        public bool closedLoop = false;
        
        [Header("Visual")]
        public float sagFactor = 0.6f;
        public float wireRadius = 0.035f;
        public int segmentsPerSpan = 24;
        public int sides = 6;
        
        [HideInInspector] public List<GameObject> wireObjects = new List<GameObject>();
        
        // === OPTIMALISASI BARU ===
        [HideInInspector] public bool isDirty = true;              // true = harus di-rebuild
        [HideInInspector] public Vector3[] lastPointPositions;     // snapshot posisi untuk deteksi perubahan
    }

    [Header("Wire Configuration")]
    public List<WireSet> wireSets = new List<WireSet>();

    [Header("Shared Resources")]
    public Material wireMaterial;

    [Header("Debug / Cleanup")]
    public bool autoCleanOrphanChildren = true;

    // === INTERNAL STATE (lebih ringkas) ===
    private bool _needsFullRebuild = false;

    private void OnEnable()
    {
        _needsFullRebuild = true; // saat script di-enable (termasuk load scene) → rebuild semua
    }

    private void OnValidate()
    {
#if UNITY_EDITOR
        EditorApplication.delayCall += DelayedRebuild;
#endif
    }

#if UNITY_EDITOR
    private void DelayedRebuild()
    {
        _needsFullRebuild = true;
        EditorApplication.delayCall -= DelayedRebuild;
    }
#endif

    private void OnDestroy()
    {
        ClearAllWires();
    }

    private void LateUpdate()
    {
        if (!isActiveAndEnabled) return;

        // 1. FULL REBUILD (OnValidate, OnEnable, Force Rebuild, tambah/hapus set)
        if (_needsFullRebuild)
        {
            RebuildAllWires();
            return;
        }

        // 2. INCREMENTAL REBUILD (hanya WireSet yang point-nya berubah)
        bool anyChanged = false;

        foreach (var set in wireSets)
        {
            if (set == null) continue;

            if (set.isDirty || HasPointsInSetMoved(set))
            {
                CleanupWireSet(set);
                if (set.points.Count >= 2)
                {
                    CreateWiresForSet(set);
                    UpdateSetPositionSnapshot(set);
                }
                set.isDirty = false;
                anyChanged = true;
            }
        }

        if (anyChanged)
        {
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
            SceneView.RepaintAll();
#endif
        }
    }

    // ==================== FULL REBUILD (dipakai saat OnValidate / Force) ====================
    private void RebuildAllWires()
    {
        if (!isActiveAndEnabled) return;

#if UNITY_EDITOR
        if (autoCleanOrphanChildren)
            CleanOrphanWires();
#endif

        foreach (var set in wireSets)
        {
            if (set == null) continue;

            CleanupWireSet(set);
            if (set.points.Count >= 2)
            {
                CreateWiresForSet(set);
                UpdateSetPositionSnapshot(set);
            }
            set.isDirty = false;
        }

        _needsFullRebuild = false;

#if UNITY_EDITOR
        EditorUtility.SetDirty(this);
        SceneView.RepaintAll();
#endif
    }

    // ==================== HELPER INCREMENTAL ====================
    private bool HasPointsInSetMoved(WireSet set)
    {
        if (set.lastPointPositions == null || set.lastPointPositions.Length != set.points.Count)
            return true;

        for (int i = 0; i < set.points.Count; i++)
        {
            var p = set.points[i];
            if (p == null) return true;
            if (Vector3.SqrMagnitude(p.position - set.lastPointPositions[i]) > 0.000001f)
                return true;
        }
        return false;
    }

    private void UpdateSetPositionSnapshot(WireSet set)
    {
        int count = set.points.Count;
        if (set.lastPointPositions == null || set.lastPointPositions.Length != count)
            set.lastPointPositions = new Vector3[count];

        for (int i = 0; i < count; i++)
        {
            var p = set.points[i];
            set.lastPointPositions[i] = p != null ? p.position : Vector3.zero;
        }
    }

    // ==================== CLEANUP ====================
    private void CleanupWireSet(WireSet set)
    {
        if (set.wireObjects == null)
        {
            set.wireObjects = new List<GameObject>();
            return;
        }

        var toDestroy = new List<GameObject>(set.wireObjects);
        set.wireObjects.Clear();

        foreach (var go in toDestroy)
        {
            if (go == null) continue;

#if UNITY_EDITOR
            if (!Application.isPlaying)
                DestroyImmediate(go, true);
            else
#endif
                Destroy(go);
        }
    }

#if UNITY_EDITOR
    private void CleanOrphanWires()
    {
        var children = new List<Transform>(transform.GetComponentsInChildren<Transform>(true));
        foreach (var child in children)
        {
            if (child == transform || child == null || child.gameObject == null) continue;

            string n = child.gameObject.name;
            if (!n.StartsWith("Wire_") && !n.Contains("WireMesh")) continue;

            bool isTracked = false;
            foreach (var set in wireSets)
            {
                if (set.wireObjects != null && set.wireObjects.Contains(child.gameObject))
                {
                    isTracked = true;
                    break;
                }
            }

            if (!isTracked)
                DestroyImmediate(child.gameObject, true);
        }
    }
#endif

    private void ClearAllWires()
    {
        foreach (var set in wireSets)
        {
            if (set != null)
            {
                CleanupWireSet(set);
                set.isDirty = true;
                set.lastPointPositions = null;
            }
        }

#if UNITY_EDITOR
        CleanOrphanWires();
        EditorUtility.SetDirty(this);
        SceneView.RepaintAll();
#endif
    }

    // ==================== CREATE WIRES ====================
    private void CreateWiresForSet(WireSet set)
    {
        int pointCount = set.points.Count;
        for (int i = 0; i < pointCount; i++)
        {
            int next = (i + 1) % pointCount;
            if (next == 0 && !set.closedLoop) break;

            Transform a = set.points[i];
            Transform b = set.points[next];
            if (a == null || b == null) continue;

            CreateSingleWireMesh(a.position, b.position, set, i);
        }
    }

    private void CreateSingleWireMesh(Vector3 start, Vector3 end, WireSet config, int segmentIndex)
    {
        Vector3 delta = end - start;
        float length = delta.magnitude;
        if (length < 0.001f) return;

        Vector3 dir = delta / length;

        Vector3 upRef = Vector3.up;
        Vector3 right = Vector3.Cross(dir, upRef).normalized;
        if (right.sqrMagnitude < 0.01f)
            right = Vector3.Cross(dir, Vector3.forward).normalized;

        Vector3 up = Vector3.Cross(dir, right).normalized;

        GameObject wireGO = new GameObject($"Wire_{config.name}_{segmentIndex}");
        wireGO.transform.SetParent(transform, false);
        wireGO.transform.localPosition = Vector3.zero;

        MeshFilter mf = wireGO.AddComponent<MeshFilter>();
        MeshRenderer mr = wireGO.AddComponent<MeshRenderer>();
        mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        if (wireMaterial != null)
            mr.material = wireMaterial;

        Mesh mesh = CreateTubeMesh(start, end, dir, right, up, length, config);
        mf.mesh = mesh;

        config.wireObjects.Add(wireGO);
    }

    private Mesh CreateTubeMesh(Vector3 start, Vector3 end, Vector3 dir, Vector3 right, Vector3 up, float totalLength, WireSet cfg)
    {
        int segments = Mathf.Max(4, cfg.segmentsPerSpan);
        int sides = Mathf.Max(3, cfg.sides);

        int vertCount = (segments + 1) * sides;
        int triCount = segments * sides * 6;

        Vector3[] vertices = new Vector3[vertCount];
        int[] triangles = new int[triCount];

        float maxSag = totalLength * cfg.sagFactor * 0.5f;

        int vIndex = 0;
        int tIndex = 0;

        for (int i = 0; i <= segments; i++)
        {
            float t = i / (float)segments;
            float sag = Mathf.Sin(t * Mathf.PI) * maxSag;

            Vector3 center = Vector3.Lerp(start, end, t) - up * sag;

            for (int s = 0; s < sides; s++)
            {
                float angle = s * Mathf.PI * 2f / sides;
                Vector3 offset = (Mathf.Cos(angle) * right + Mathf.Sin(angle) * up) * cfg.wireRadius;
                vertices[vIndex++] = center + offset;
            }
        }

        for (int seg = 0; seg < segments; seg++)
        {
            for (int s = 0; s < sides; s++)
            {
                int a = seg * sides + s;
                int b = seg * sides + (s + 1) % sides;
                int c = (seg + 1) * sides + (s + 1) % sides;
                int d = (seg + 1) * sides + s;

                triangles[tIndex++] = a; triangles[tIndex++] = b; triangles[tIndex++] = c;
                triangles[tIndex++] = a; triangles[tIndex++] = c; triangles[tIndex++] = d;
            }
        }

        Mesh mesh = new Mesh
        {
            name = "WireMesh_" + cfg.name,
            vertices = vertices,
            triangles = triangles
        };

        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
        mesh.RecalculateBounds();
        return mesh;
    }

    // ==================== CONTEXT MENU ====================
    [ContextMenu("Force Full Rebuild + Clean")]
    private void ForceRebuildAndClean()
    {
        ClearAllWires();
        RebuildAllWires();
    }

    [ContextMenu("Clean Orphans Only (Debug)")]
    private void CleanOrphans()
    {
#if UNITY_EDITOR
        CleanOrphanWires();
        SceneView.RepaintAll();
#endif
    }
}






#if UNITY_EDITOR
[CustomEditor(typeof(PowerPoleWiringSystem))]
public class PowerPoleWiringSystem_InspectorFooter : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUILayout.Space(15);
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        GUILayout.Space(5);

        EditorGUILayout.LabelField("Thanks for using Ciihuy Unity Tools", EditorStyles.boldLabel);
        GUILayout.Space(5);

        if (GUILayout.Button("More Tools"))
        {
            Application.OpenURL("https://unity.ciihuy.com");
        }

        if (GUILayout.Button("Support Us"))
        {
            Application.OpenURL("https://ciihuy.com/supportus/?lang=en");
        }

        GUILayout.Space(5);
    }
}
#endif
