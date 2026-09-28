using UnityEngine;

public class AerialArray : MonoBehaviour
{

    public GameObject prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Starting position and rotation -- both of these mean the same thing
        for(int i = 1; i < 10; i++){
            Instantiate(prefab, new Vector3(i * 3, 0, 0), Quaternion.identity);
            Debug.Log(i);
        }
    }

    // pick a random Prefab from an array of aerial meshes
    // create a slightly randomised rotation on the Y axis
    // 


    // Update is called once per frame
    void Update()
    {
        
    }
}
