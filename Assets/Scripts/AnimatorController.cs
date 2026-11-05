using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator objectToAnimate;
    public string booleanName;
    //controls if this script is able to be interacted with
    public bool isLocked = false;
    public bool hasBeenInteractedWith = false;

    public bool isMask = false;
    public GameObject playerCamera;

    public Light DirectionalLightUnder;
    public Light DirectionalLightOver;

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

    // the Mask's AnimationEvent starts this
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


    // WellClimbTransform AnimationEvent 1 this

    private void wellClimb(){
        // FADE TO WHITE


        DirectionalLightOver.enabled = true;
        DirectionalLightUnder.enabled = false;


    }



    // WellClimbTransform AnimationEvent 2
    private void rooneyHug(){
        // play some spooky sound idk
        Debug.Log("Rooney Hug!");
        // DEACTIVATE THE CAMERA MOVEMENT
        // ROTATE THE TRANSFORM TO LINE UP THE CAMERA TO ROONEY'S FACE
        // FADE TO BLACK
    }




}

