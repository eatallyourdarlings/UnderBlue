// using UnityEngine;

// SCRAPYARD 

// // this script is about replicating Blender's Array modifier basically, but mirrored/doubled, and adding a little offset to each of the object's positions using a scrolling noise texture.
// public class PrefabLooper : MonoBehaviour
// {

//     public GameObject[] prefabs;
//     public Transform centrePosition = transform;

//     //half the number of total in the arrar
//     public int count = 11;
//     private int totalCount;
//     // final count will be xCount * zCount * 2;
//     // private float startingX;
//     // private float startingZ;
//     public float noiseMultiplier = 0.022f;
//     public float distanceMultiplier = 22f;
//     public float speed = 0.22f;
//     private GameObject[,] terrain;
//     private GameObject[,] arrayNegative;
//     private GameObject[,] arrayPositive;
    

//     void Start()
//     {
//         // Debug.Log(startingX);
//         // Debug.Log(startingZ);
//         //

//         //start from top-left!
//         private int totalCount = count * 4;

//         terrain = new GameObject[xCount * 4, zCount * 4];

//         // arrayNegative = new GameObject[xCount, zCount];
//         // arrayPositive = new GameObject[xCount, zCount];

//         // do a wavy plane of cubes
//         // for(int x = 1; x < zCount; x++){
//         //     Debug.Log(x);
//         //     for(int z = 1; z < zCount; z++ ){
//         //         float y = Mathf.PerlinNoise(x * noiseMultiplier, z * noiseMultiplier);
//         //         // int y = x+z;
//         //         Instantiate(cube, new Vector3(x,y,z), Quaternion.identity);
//         //     }
//         // }


//         //negatives

//         // OK SO I KNOW THE PROBLEM IS BECAUSE I WAS TRYING TO DIVIDE THE INDEX NUMBERS AND THATS SILLY AND SO I WAS GETTING LESS INSTANTIATIONS

//         // SO INSTEAD I COULD MULTIPLY THE newX and newZ by a quadrant value 1-4 and I could simplify the loop!


//     // global position of parent is (576, 0, 6.5)
//     // USING LOCAL TRANSFORM POSITION

//         //quadrants!
//         // 1 x,z
//         // 2 x,-z
//         // 3 -x,-z
//         // 4 -x,z

//         // start at 1 to avoid dividing by 0
//         int quadrant = 0;
//         for(int x = 0; x < xCount + (xCount * quadrant); x++)
//         {
//             // if we're divisible by the number in each quarter we're at the boundary of a quadrant
//             // if (x % xCount == 0){
//             //         quadrant++;
//             //         // after 32,65
//             //         // printing this 132 times; that's xCount * 4
//             //         Debug.Log($"quadrant is {quadrant} asf");
//             //     }

//             for(int z = 0; z < zCount + (zCount * quadrant); z++)
//             {

//                 AddToArray(x, z, quadrant);
//             }
//         }

//         // got 9934 prefabs

//         // quadrant = 2;
//         // for(int x = xCount; x < xCount * quadrant; x++)
//         // {
//         //     for(int z = zCount; z < zCount * quadrant; z++)
//         //     {
//         //         AddToArray(x / 2, -z / 2);
//         //         AddToArray(x / 4, -z / 4);
//         //     }
//         // }

//         // for(int x = xCount * 2; x < xCount * 3; x++)
//         // {
//         //     for(int z = zCount * 2; z < zCount * 3; z++)
//         //     {
//         //         // AddToArray(-x / 3, z / 3);
//         //         AddToArray(-x, z);
//         //     }
//         // }

//         // for(int x = xCount * 3; x < xCount * 4; x++)
//         // {
//         //     for(int z = zCount * 3; z < zCount * 4; z++)
//         //     {
//         //         // AddToArray(-x / 4, -z / 4);
//         //         AddToArray(-x, -z);
//         //     }
//         // }





//         //positives start where the index is the same as the xCount / zCount
//         // for(int x = xCount; x < xCount * 2; x++)
//         // {
//         //     for(int z = zCount; z < zCount * 2; z++ )
//         //     {
//         //         AddToArray(x,z,false);
//         //     }
//         // }
//     }

//     void AddToArray(int x, int z, int quadrant){

//         switch(quadrant){
//         case 1:
//             x = x;
//             z = z;
//             break;
//         case 2:
//             x = -x;
//             z = z;
//             break;
//         case 3:
//             x = -x;
//             z = -z;
//             break;
//         case 4:
//             x = x;
//             z = -z;
//             break;
//         }

//         // Debug.Log();

//         // mirrored means positions are in the negative axis
//         // float mirrorFactor = 1;


//         float newX = transform.position.x + x * distanceMultiplier;
//         float newZ = transform.position.z + z * distanceMultiplier;
//         // Debug.Log($"{newX}, {newZ}");
        
//         x = Mathf.Abs(x);
//         z = Mathf.Abs(z);
//         Debug.Log($"{x}, {z} adding to Array [:");
//         // this is the bit where you would choose a random prefab from the array of meshes
//         terrain[x,z] = Instantiate(prefabs[0], new Vector3(newX, 0, newZ), Quaternion.identity, transform);



//         // if (mirror){
//         //     // mirrorFactor = -mirrorFactor;
//         //     arrayNegative[x,z] = Instantiate(prefabs[0], new Vector3(-newX, 0, -newZ), Quaternion.identity, transform);
//         // }
//         // else{
//         //     arrayPositive[x,z] = Instantiate(prefabs[0], new Vector3(newX, 0, newZ), Quaternion.identity, transform);
//         // }


        

        
        
//     }


//     // PROCEDURAL PLANE -- advice from Max is to not do it.
//     // how big is your plane?
//     // how far apart are the vertices (1m?)
//     // apply offset to each point of the vertex
//     // DOING PROCEDURAL MESH GENERATION IS REALLY TEDIOUS
//     // pick a random Prefab from an array of aerial meshes
//     // create a slightly randomised rotation on the Y axis


//     // Update is called once per frame
//     void Update()
//     {
//         for(int x = 0; x < xCount; x++)
//         {
//             // Debug.Log(x);
//             for(int z = 0; z < zCount; z++ )
//             {
//                 // wobbling in the oncewaves
//                 // scrolling the noise texture!
//                 float newY = Mathf.PerlinNoise(x * noiseMultiplier + Time.time * speed, z * noiseMultiplier + Time.time * speed) * 3f;
//                 // terrain[x, z].transform.position = new Vector3(terrain[x, z].transform.position.x, newY, terrain[x, z].transform.position.z);
//             }

        
//         }
//     }
// }