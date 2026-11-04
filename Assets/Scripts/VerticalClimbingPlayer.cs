using UnityEngine;

public class VerticalClimbingPlayer : MonoBehaviour
{

    public GameObject wellClimbTransform;
    private FirstPersonDrifter drifter;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ACTIVATE VERTICAL CLIMB COMPONENT SO THAT THESE ARE CALLED ON START
        
        // MaskController sets this off!

        // get values as a backup then store them to change them back again later
        // MouseLook.Sensitivity
        // MouseLook.MaximumY
        // MouseLook.MinimumY
            // etc

        // Set Parent to PlayerClimbTransform
        // 

        // move the Transform upwards


        // Changing the parent will modify the parent-relative position, scale and rotation but keep the world space position, rotation and scale the same.



        // HelperFunctions.SetParent(transform.gameObject, newParent);

                //Makes the GameObject "newParent" the parent of the GameObject "player".

        Debug.Log("Climby Script Activate!");
        transform.parent = wellClimbTransform.transform;

        wellClimbTransform.GetComponent<AnimatorController>().ObjectClickedOn();

        drifter = GetComponent<FirstPersonDrifter>();
        // drifter.gravity = 0;
        // Debug.Log($"Drifter Gravity: {drifter.gravity}");
        drifter.enabled = false;

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




        // RESET THE PARENT TRANSFORM
        // this.transform.parent = null;
        
    }


    

    // Update is called once per frame
    void Update()
    {
        // what da hell who changed the gravity up on me
    }

}
