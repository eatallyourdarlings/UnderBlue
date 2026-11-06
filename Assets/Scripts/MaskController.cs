using UnityEngine;

public class MaskController : MonoBehaviour
{


    public VerticalClimbingPlayer climbingPlayer;
    public AnimatorController wellClimbAnimator;
    

    // Triggered by end of the MaskPickup AnimationEvent

    public void MaskPickup()
    {
        Debug.Log("Mask Pickup (^0.0^)");
        climbingPlayer.enabled = true;
        wellClimbAnimator.ObjectClickedOn();
    }
}
