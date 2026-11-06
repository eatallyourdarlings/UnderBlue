using UnityEngine;

public class MaskController : MonoBehaviour
{


    public VerticalClimbingPlayer climbingPlayer;


    // Triggered by the MaskPickup AnimationEvent

    public void MaskPickup()
    {
        Debug.Log("Mask On (^0.0^) activating VerticalClimbingPlayer script");
        climbingPlayer.enabled = true;
    }
}
