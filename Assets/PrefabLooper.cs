using UnityEngine;

public class PrefabLooper : MonoBehaviour
{

    public GameObject prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int loops = 10;
    public float step = 0.0123f;
    public float speed = 0.1f;
    private GameObject[,] terrain;

    void Start()
    {
        terrain = new GameObject[loops,loops];

        // do a wavy plane of cubes
        // for(int x = 1; x < loops; x++){
        //     Debug.Log(x);
        //     for(int z = 1; z < loops; z++ ){
        //         float y = Mathf.PerlinNoise(x * step, z * step);
        //         // int y = x+z;
        //         Instantiate(cube, new Vector3(x,y,z), Quaternion.identity);
        //     }
        // }

        // make it an ocean
        // scrolling the noise texture!

        for(int x = 1; x < loops; x++)
        {
            for(int z = 1; z < loops; z++ )
            {
                // int y = x+z;
                terrain[x,z] = Instantiate(prefab, new Vector3(x,0,z), Quaternion.identity);
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
        for(int x = 1; x < loops; x++)
        {
            // Debug.Log(x);
            for(int z = 1; z < loops; z++ )
            {
                float y = Mathf.PerlinNoise(x * step + Time.time * speed, z * step + Time.time * speed) * 3f;
                terrain[x, z].transform.position = new Vector3(x,y,z);

            }

        
        }
    }
}