using UnityEngine;

public class MaskController : MonoBehaviour
{

    public GameObject wellClimbTransform;
    public GameObject wellClimbTrigger;
    public VerticalClimbingPlayer climb;


    // WellClimb script just drags the player upwards, then changes the PostProcessing.

    public void PutMaskOn()
    {
        Debug.Log("Mask On (^0.0^) ");
        Debug.Log("Set Post Processy");
        climb.enabled = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
            // get PostProcessing Asset
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
