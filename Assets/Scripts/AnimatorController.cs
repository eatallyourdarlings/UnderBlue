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

    public GameObject whiteImage;
    public GameObject blackImage;


    public Transform maskTransform;
    public Transform cameraMaskTransform;
    public GameObject playerCamera;

    public GameObject rooneyMesh;
    // public GameObject megastructureAudio;
    public GameObject desertWind;
    public GameObject breathAudio;

    public GameObject umbilicalAnchor;
    public GameObject wiringSystem;

    public FirstPersonDrifter drifter;
    //public VerticalClimbingPlayer climbingPlayer;

    

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

        // TOGGLE WHITE
        whiteImage.SetActive(true);
        // canvasImage.GetComponent<Image>().colour = alpha lerp whatevver;
        // FADE TO WHITE AND BACK

        // DirectionalLightOver.enabled = true;
        DirectionalLightOver.SetActive(true);
        // DirectionalLightUnder.enabled = false;
        DirectionalLightUnder.SetActive(false);
    }

    private void wellExit(){
        Debug.Log("Well Exit!");
        whiteImage.SetActive(false);

        // MOVE THE UMBILICAL PARENT TO ROONEY'S MOUTH
        umbilicalAnchor.transform.position = new Vector3(2.2f,1.3f,0f);
    }

    // WellClimbTransform AnimationEvent 2
    private void rooneyHug(){
        whiteImage.SetActive(false);
        // play some spooky sound idk
        Debug.Log("Rooney Hug!");

        desertWind.SetActive(true);

        // DEACTIVATE THE CAMERA MOVEMENT

        // ROTATE THE TRANSFORM TO LINE UP THE CAMERA TO ROONEY'S FACE?

        
    }

    // WellClimbTransform AnimationEvent 3
    private void rooneyMerge(){
        Debug.Log("Rooney Merge!");

        // FADE BACK IN FROM BLACK
        blackImage.SetActive(true);

        // stop the humming? it shouldnt be looping


        // disappear rooney
        rooneyMesh.SetActive(false);

        // megastructureAudio.SetActive(true);

    }

    private void rooneyGone(){
        blackImage.SetActive(false);


        // turn on the drifter script
        // reactive the drifter movement
        drifter.enabled = true;
        drifter.walkSpeed = 3.0f;
        // slower movement variables

        // breathing sound

        breathAudio.SetActive(true);
        wiringSystem.SetActive(false);
    }
}

