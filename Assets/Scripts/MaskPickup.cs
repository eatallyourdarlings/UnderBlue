using UnityEngine;

// the functions in this like SetParent could be handy on other objects, but that's an optimisation for later...

public class MaskPickup : MonoBehaviour
{
    public GameObject camera;
    // public GameObject 

    public void doPickup(){
        
        // change the parent to the Camera

        Debug.Log("Mask Do Pickup!");
        // HelperFunctions.SetParent(gameObject, camera);
        transform.localPosition = new Vector3(0,0,0.6f);
        transform.localRotation = Quaternion.Euler(new Vector3(-90f,0,0));

        // play animation of mask pickup
        // change the Post Processing settings to be a heavy, offset vignette



    


//     // do something with the lighting?
//         // increase the width of the spotlight??

//     // start the mask-breathing SFX
//     // start the spooky chime sound that Josie made at Keon Park
//         // after that, start Rooney's singing track

//     // change the Character controller state to climbing??

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
