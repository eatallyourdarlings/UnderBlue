using UnityEngine;

public class VerticalClimbingPlayer : MonoBehaviour
{

    public GameObject newParent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ACTIVATE VERTICAL CLIMB COMPONENT SO THAT THESE ARE CALLED ON START

        // get values as a backup then store them to change them back again later
        // MouseLook.Sensitivity
        // MouseLook.MaximumY
        // MouseLook.MinimumY
            // etc

        // Set Parent to PlayerClimbTransform
        // 

        // move the Transform upwards
        // don't use another fucking animation


        // Changing the parent will modify the parent-relative position, scale and rotation but keep the world space position, rotation and scale the same.



        // HelperFunctions.SetParent(transform.gameObject, newParent);

                //Makes the GameObject "newParent" the parent of the GameObject "player".

        Debug.Log("Climby On!");
        transform.parent = newParent.transform;

        //Display the parent's name in the console.
        Debug.Log("Parent: " + transform.parent.name);

        // Check if the new parent has a parent GameObject.
        if (newParent.transform.parent != null)
        {
            //Display the name of the grand parent of the player.
            Debug.Log("Grand parent: " + transform.parent.parent.name);
        }

        // this.transform.parent = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        // what da hell who changed the gravity up on me
    }

}
