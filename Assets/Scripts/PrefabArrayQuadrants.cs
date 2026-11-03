using UnityEngine;

// this script is about replicating Blender's Array modifier basically, but mirrored/doubled, and adding a little offset to each of the object's positions using a scrolling noise texture.
public class PrefabArrayQuadrant : MonoBehaviour
{

    public GameObject[] aerialMeshes;
    public GameObject baseMesh;

    public int quadrantCount = 11;
    public float noiseScale = 0.011f;
    public float noiseSpeed = 0.11f;
    public float distanceMultiplier = 22f;
    public float rotationRange = 22f;

    // count of this array should be quadrantCount * quadrantCount * 4;
    private GameObject[,] aerialObjects;
    private float startingX;
    private float startingZ;
    private Vector3 centrePosition;
    

    void Start()
    {
        aerialObjects = new GameObject[quadrantCount * 2, quadrantCount * 2];
        centrePosition = transform.position;

        // OK SO I KNOW THE PROBLEM IS BECAUSE I WAS TRYING TO DIVIDE THE INDEX NUMBERS AND THATS SILLY BECAUSE THEY GOTTA BE INDICES AND SO I WAS GETTING LESS INSTANTIATIONS -- THIS COULD BE AN INTERESTING WAY TO CREATE SOME VARIATION THROUGH COMPOUND ERROR THOUGH I GUESS I'LL SEE


    // global position of parent is (576, 0, 6.5)
    // TRY USING LOCAL TRANSFORM POSITION?

        //quadrants!
        // start at 1 to avoid dividing by 0??
        // 1 x,z
        // 2 x,-z
        // 3 -x,-z
        // 4 -x,z

        startingX = centrePosition.x - quadrantCount * distanceMultiplier;
        startingZ = centrePosition.x - quadrantCount * distanceMultiplier;
        Debug.Log($"{startingX}, {startingZ} adding to Array [:");
        // Vector3 startingPosition = new Vector3(startingX, 0, startingZ);

        for(int x = 0; x < quadrantCount * 2; x++)
        {
            for(int z = 0; z < quadrantCount * 2; z++)
            {
                float xPos =  startingX + (x * distanceMultiplier) - distanceMultiplier / 2;
                float zPos =  startingZ + (z * distanceMultiplier) - distanceMultiplier / 2;
                AddToArray(x, z, xPos, zPos);
            }
        }
    }

    void AddToArray(int x, int z, float xPos, float zPos){

        // float newX = transform.position.x + x * distanceMultiplier;
        // float newZ = transform.position.z + z * distanceMultiplier;
        // Debug.Log($"{newX}, {newZ}");
        
        // x = Mathf.Abs(x);
        // z = Mathf.Abs(z);
        
        // create a random rotation here and use it for both??

        float yRotation = Random.Range(-rotationRange, rotationRange);
    
        // this is the bit where you would choose a random prefab from the array of meshes
        GameObject mesh = aerialMeshes[Random.Range(0, aerialMeshes.Length)];

        aerialObjects[x,z] = Instantiate(mesh, new Vector3(xPos, 0, zPos), Quaternion.Euler(0, yRotation, 0), transform);
        
        // Quaternion.identity is (0,0,0) as a Vector3
        Instantiate(baseMesh, new Vector3(xPos, 0, zPos), Quaternion.Euler(0, yRotation, 0), transform);

        // last variable in Instantiate is the parent -- set to the object that has this script on it.
        
    }


    // PROCEDURAL PLANE -- advice from Max is to not do it.
    // how big is your plane?
    // how far apart are the vertices (1m?)
    // apply offset to each point of the vertex
    // DOING PROCEDURAL MESH GENERATION IS REALLY TEDIOUS
    // pick a random Prefab from an array of aerial meshes
    // create a slightly randomised rotation on the Y axis


    // Update is called once per frame
    void Update()
    {
        for(int x = 0; x < quadrantCount * 2; x++)
        {
            // Debug.Log(x);
            for(int z = 0; z < quadrantCount * 2; z++ )
            {
                // wobbling in the oncewaves
                // scrolling the noise texture!
                float newY = Mathf.PerlinNoise(x * noiseScale + Time.time * noiseSpeed, z * noiseScale + Time.time * noiseSpeed) * 3f;
                aerialObjects[x, z].transform.position = new Vector3(aerialObjects[x, z].transform.position.x, newY, aerialObjects[x, z].transform.position.z);
            }

        
        }
    }
}