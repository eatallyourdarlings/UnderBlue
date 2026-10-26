using UnityEngine;

// this script is about replicating Blender's Array modifier basically, but mirrored/doubled, and adding a little offset to each of the object's positions using a scrolling noise texture.
public class PrefabLooper : MonoBehaviour
{

    public GameObject[] prefabs;
   

    //half the number of total in the arrar
    public int xCount = 33;
    public int zCount = 33;
    // final count will be xCount * zCount * 2;
    // private float startingX;
    // private float startingZ;
    public float noiseMultiplier = 0.022f;
    public float distanceMultiplier = 22f;
    public float speed = 0.22f;
    public GameObject[,] terrain;
    

    void Start()
    {
        // Debug.Log(startingX);
        // Debug.Log(startingZ);
        //

        terrain = new GameObject[xCount * 2,zCount * 2];

        // do a wavy plane of cubes
        // for(int x = 1; x < zCount; x++){
        //     Debug.Log(x);
        //     for(int z = 1; z < zCount; z++ ){
        //         float y = Mathf.PerlinNoise(x * noiseMultiplier, z * noiseMultiplier);
        //         // int y = x+z;
        //         Instantiate(cube, new Vector3(x,y,z), Quaternion.identity);
        //     }
        // }



        //negatives
        for(int x = 0; x < xCount; x++)
        {
            for(int z = 0; z < zCount; z++ )
            {
                AddToTerrain(x,z,true);
            }
        }


        //positives start where the index is the same as the xCount / zCount
        for(int x = xCount; x < xCount * 2; x++)
        {
            for(int z = zCount; z < zCount * 2; z++ )
            {
                AddToTerrain(x,z,false);
            }
        }
    }

    void AddToTerrain(int x, int z, bool mirror){
        // mirrored means positions are in the negative axis
        float mirrorFactor = 1;
        if (mirror){
            // Debug.Log("mirror!");
            mirrorFactor = -mirrorFactor;
        }

        float newX = transform.position.x + x * distanceMultiplier * mirrorFactor;
        float newZ = transform.position.z + z * distanceMultiplier * mirrorFactor;
        // this is the bit where you choose a random prefab

        //arrayPositive
        terrain[x,z] = Instantiate(prefabs[0], new Vector3(newX, 0, newZ), Quaternion.identity, transform);
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
        for(int x = 0; x < xCount; x++)
        {
            // Debug.Log(x);
            for(int z = 0; z < zCount; z++ )
            {
                // wobbling in the oncewaves
                // scrolling the noise texture!
                float newY = Mathf.PerlinNoise(x * noiseMultiplier + Time.time * speed, z * noiseMultiplier + Time.time * speed) * 3f;
                terrain[x, z].transform.position = new Vector3(terrain[x, z].transform.position.x, newY, terrain[x, z].transform.position.z);
            }

        
        }
    }
}