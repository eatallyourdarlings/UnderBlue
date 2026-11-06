using UnityEngine;

public class MaskController : MonoBehaviour
{


    public VerticalClimbingPlayer climbingPlayer;
    

    // Triggered by the MaskPickup AnimationEvent

    public void MaskPickup()
    {
        Debug.Log("Mask Pickup (^0.0^)");
        climbingPlayer.enabled = true;
    }
}
