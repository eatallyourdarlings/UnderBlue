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



    private void MaskClickedOn(){
        // change the parent to the Camera
        transform.parent = playerCamera.transform;

        // set the position of the MaskTransform
        // transform.localPosition = new Vector3(0f,0f,-0.5f);
        // transform.localRotation = transform.parent.rotation;
        // transform.localRotation = Quaternion.Euler(new Vector3(90f,0f,0f));

        Debug.Log("Mask Clicked On!");
        // HelperFunctions.SetParent(gameObject, camera);
        // transform.localPosition = new Vector3(0,0,0.6f);
        // transform.localRotation = Quaternion.Euler(new Vector3(-90f,0f,0f));


        // make the umbilical appear


                // do something with the lighting?
            // increase the width of the spotlight


        // lock player movement (reduced speed)
        // disable the player camera script

            // change the Post Processing settings to be a heavy, offset vignette
        // start the mask-breathing SFX
        // start the spooky chime sound that Josie made at Keon Park
            // after that, start Rooney's singing 
        // change the Character controller state to climbing??

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




}

