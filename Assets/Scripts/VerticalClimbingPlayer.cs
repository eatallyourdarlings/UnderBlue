using UnityEngine;

public class VerticalClimbingPlayer : MonoBehaviour
{

    public GameObject wellClimbTransform;
    public FirstPersonDrifter drifter;


    void Start()
    {
        //ACTIVATE VERTICAL CLIMB COMPONENT SO THAT THESE ARE CALLED ON START
        
        // MaskController sets this off!

        // get values as a backup then store them to change them back again later
        // MouseLook.Sensitivity
        // MouseLook.MaximumY
        // MouseLook.MinimumY
            // etc

        Debug.Log("Climby Script Activate!");
        transform.parent = wellClimbTransform.transform;

        // drifter = GetComponent<FirstPersonDrifter>();
        // drifter.gravity = 0;
        // Debug.Log($"Drifter Gravity: {drifter.gravity}");
        drifter.enabled = false;
        transform.localPosition = new Vector3(0f,0f,0f);

        //Display the parent's name in the console.
        Debug.Log("Parent: " + transform.parent.name);

        // Check if the new parent has a parent GameObject.
        if (wellClimbTransform.transform.parent != null)
        {
            //Display the name of the grand parent of the player.
            Debug.Log("Grand parent: " + transform.parent.parent.name);
        }

        // get PostProcessing Asset
        // Debug.Log("Set Post Processy");

        // drags the player upwards, then changes the PostProcessing.
        // parent player to transform



        // RESET THE PARENT TRANSFORM
        // this.transform.parent = null;
        
    }


    

    // Update is called once per frame
    void Update()
    {
        // what da hell who changed the gravity up on me
    }

}
