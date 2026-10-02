using UnityEngine;

public class PrefabLooper : MonoBehaviour
{

    public GameObject[] prefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int xCount = 10;
    public int zCount = 10;
    // private float startingX;
    // private float startingZ;
    public float noiseMultiplier = 0.0123f;
    public float distanceMultiplier = 5.5f;
    public float speed = 0.1f;
    private GameObject[,] terrain;
    

    void Start()
    {
        // Debug.Log(startingX);
        // Debug.Log(startingZ);
        terrain = new GameObject[xCount,zCount];

        // do a wavy plane of cubes
        // for(int x = 1; x < zCount; x++){
        //     Debug.Log(x);
        //     for(int z = 1; z < zCount; z++ ){
        //         float y = Mathf.PerlinNoise(x * noiseMultiplier, z * noiseMultiplier);
        //         // int y = x+z;
        //         Instantiate(cube, new Vector3(x,y,z), Quaternion.identity);
        //     }
        // }

        // make it an ocean
        // scrolling the noise texture!

        for(int x = 0; x < xCount; x++)
        {
            for(int z = 0; z < zCount; z++ )
            {
                // int y = x+z;
                float newX = transform.position.x + x * distanceMultiplier;
                float newZ = transform.position.z + z * distanceMultiplier;
                // this is the bit where you choose a random prefab
                terrain[x,z] = Instantiate(prefabs[0], new Vector3(newX, 0, newZ), Quaternion.identity);
            }
        }
    }


    // PROCEDURAL PLANE
    // how big is your plane?
    // how far apart are the vertices (1m?)
    // apply offset to each point of the vertex
    // DOING PROCEDURAL MESH GENERATION IS REALLY TEDIOUS
    // pick a random Prefab from an array of aerial meshes
    // create a slightly randomised rotation on the Y axis
    // 


    // Update is called once per frame
    void Update()
    {
        for(int x = 0; x < xCount; x++)
        {
            // Debug.Log(x);
            for(int z = 0; z < zCount; z++ )
            {

                float newY = Mathf.PerlinNoise(x * noiseMultiplier + Time.time * speed, z * noiseMultiplier + Time.time * speed) * 3f;
                terrain[x, z].transform.position = new Vector3(terrain[x, z].transform.position.x, newY, terrain[x, z].transform.position.z);
            }

        
        }
    }
}