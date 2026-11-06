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


    public Transform maskTransform;
    public Transform cameraMaskTransform;
    public GameObject playerCamera;
    

    // public Light DirectionalLightUnder;
    public GameObject DirectionalLightUnder;
    // public Light DirectionalLightOver;
    public GameObject DirectionalLightOver;

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
            MaskClickedOn(); 
            // transform.GetChild(0).gameObject.
        }
    }



// MOVED TO MASK CONTROLLER
    // void Update(){
    //     if (objectToAnimate.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f){
    //         Debug.Log("Animation done.");

    //         if(isMask){
    //             MaskPickup(); 
    //             // transform.GetChild(0).gameObject.getComponent<MaskPickup>
    //         }
    //     }
    // }


    // // AFTER THE MASK ANIMATION
    // private void MaskPickup(){
    //     Debug.Log("Mask Pickup");

    //     // START THE PLAYER CLIMB SCRIPT
    //     // climbingPlayer.SetActive(false);
    // }

    private void MaskClickedOn(){

        Debug.Log("Mask Clicked On!");

        // change the parent to the Camera
        maskTransform.parent = cameraMaskTransform;

    }





    // WellClimbTransform AnimationEvent 1 this
    private void wellClimb(){
        // FADE TO WHITE


        // DirectionalLightOver.enabled = true;
        DirectionalLightOver.SetActive(true);
        // DirectionalLightUnder.enabled = false;
        DirectionalLightUnder.SetActive(false);
    }



    // WellClimbTransform AnimationEvent 2
    private void rooneyHug(){
        // play some spooky sound idk
        Debug.Log("Rooney Hug!");

        // DEACTIVATE THE CAMERA MOVEMENT
        // ROTATE THE TRANSFORM TO LINE UP THE CAMERA TO ROONEY'S FACE
        // FADE TO BLACK
    }

    // WellClimbTransform AnimationEvent 3
    private void rooneyMerge(){
        Debug.Log("Rooney Merge!");

        // reactive the drifter movement
        // FADE BACK IN FROM BLACK
    }





}

