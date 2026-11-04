using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator objectToAnimate;
    public string booleanName;
    public bool isMask = false;
    //controls if this script is able to be interacted with
    public bool isLocked = false;
    public bool hasBeenInteractedWith = false;

    public GameObject playerCamera;

    //The function called by the InteractionController
    public void ObjectClickedOn()
    {
        // if(isLocked == false)
        if(!hasBeenInteractedWith && !isLocked)
        {
            objectToAnimate.SetBool(booleanName, true);
            // Debug.Log($"{booleanName} should be true");
            hasBeenInteractedWith = true;
            isLocked = true;
        }

        if(isMask){
            maskPickup(); 
            // transform.GetChild(0).gameObject.
            // GetComponent<MaskPickup>().doPickup();
        }
    }

    private void maskPickup(){
        // change the parent to the Camera
        transform.parent = playerCamera.transform;

        Debug.Log("Mask Do Pickup!");
        // HelperFunctions.SetParent(gameObject, camera);
        transform.localPosition = new Vector3(0,0,0.6f);
        transform.localRotation = Quaternion.Euler(new Vector3(-90f,0,0));

        // play animation of mask pickup
        // change the Post Processing settings to be a heavy, offset vignette    

        // do something with the lighting?
            // increase the width of the spotlight
        // start the mask-breathing SFX
        // start the spooky chime sound that Josie made at Keon Park
            // after that, start Rooney's singing 
        // change the Character controller state to climbing??

}
}

