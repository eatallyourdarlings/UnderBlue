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

    //The function called by the InteractionController
    public void ObjectClickedOn()
    {
        // if(isLocked == false)
        if(!hasBeenInteractedWith && !isLocked)
        {
            objectToAnimate.SetBool(booleanName, true);
            hasBeenInteractedWith = true;
            isLocked = true;
        }

        if(isMask){
            // transform.GetChild(0).gameObject.
            GetComponent<MaskPickup>().doPickup();
        }
    }
}

