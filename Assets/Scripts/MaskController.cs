using UnityEngine;

public class MaskController : MonoBehaviour
{


    public VerticalClimbingPlayer climbingPlayer;
    public AnimatorController wellClimbAnimator;
    
    public GameObject rooneyHum;
    

    public GameObject wiringSystem;
    

    // Triggered by end of the MaskPickup AnimationEvent

    public void MaskPickup()
    {
        Debug.Log("Mask Pickup (^0.0^)");
        climbingPlayer.enabled = true;
        wellClimbAnimator.ObjectClickedOn();
        // play Rooney
        // rooneyHum.enabled = true;
        rooneyHum.SetActive(true);
        wiringSystem.SetActive(true);

        // show the umbilical cable system
    }
}
