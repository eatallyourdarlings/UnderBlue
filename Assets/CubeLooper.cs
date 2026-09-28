using UnityEngine;

public class CubeLooper : MonoBehaviour
{

    public GameObject cube;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //Make a qubert level
    void Start()
    {
        for(int x = 1; x < 10; x++){
            Debug.Log(x);
            for(int z = 1; z < 10; z++ ){
                int y = x+z;
                Instantiate(cube, new Vector3(x,y,z), Quaternion.identity);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
