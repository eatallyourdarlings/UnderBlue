using UnityEngine;

// the functions in this like SetParent could be handy on other objects, but that's an optimisation for later...

public class MaskPickup : MonoBehaviour
{
    public GameObject camera;

    public void doPickup(){
        
        // change the parent to the Camera

        Debug.Log("do pickup");
        SetParent(camera);

        // play animation of mask pickup
        // change the Post Processing settings to be a heavy, offset vignette



    


//     // do something with the lighting?
//         // increase the width of the spotlight??

//     // start the mask-breathing SFX
//     // start the spooky chime sound that Josie made at Keon Park
//         // after that, start Rooney's singing track

//     // change the Character controller state to climbing??

    }


    // Changing the parent will modify the parent-relative position, scale and rotation but keep the world space position, rotation and scale the same.
    private void SetParent(GameObject newParent)
    {
        //Makes the GameObject "newParent" the parent of the GameObject "player".
        transform.parent = newParent.transform;

        //Display the parent's name in the console.
        Debug.Log("Parent: " + transform.parent.name);

        // Check if the new parent has a parent GameObject.
        if (newParent.transform.parent != null)
        {
            //Display the name of the grand parent of the player.
            Debug.Log("Grand parent: " + transform.parent.parent.name);
        }
    }

// public Collider collider;

//     //Upon collision with another GameObject, this GameObject will reverse direction
//     private void OnTriggerEnter(Collider other)
//     {
//         // speed = speed * -1;
//         Debug.Log($"colliddled with {other}");

//         if ((Input.GetMouseButton(0)) and (other.tag == "Player")) 
//         {
//             Debug.Log("Player pressed left click.");
//         }

//         // if other has Player tag

//         // Input.GetAxis("Horizontal")
//     }
}
