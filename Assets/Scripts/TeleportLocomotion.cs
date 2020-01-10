using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLocomotion : MonoBehaviour
{
    public LineRenderer laserLine; // Reference to laser line in the scene

    Vector3 teleportPosition; // Remembers the last hit point (from raycast)

    public Transform xrRig; // This is whatr we're moving!

    public string teleportButtonName;

    public Transform headset; // To calc offset from xr rig

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        laserLine.SetPosition(0, transform.position); // Setting the start position of the laser

        if(Input.GetButton(teleportButtonName) == true) // Button is held down
        {
            laserLine.enabled = true; // Turn on the laser 

            RaycastHit raycastHitInfo; // Stores info about what was hit (and the position of the hit)

            if(Physics.Raycast(transform.position, transform.forward, out raycastHitInfo, Mathf.Infinity) == true) // If we hit something (a collider)
            {
                laserLine.SetPosition(1, raycastHitInfo.point); // Define the end of the laser

                teleportPosition = raycastHitInfo.point; // Take note of the position the raycast hit
            }
            else // In other words, the raycast did not hit anything, so....
            {
                laserLine.SetPosition(1, transform.position + transform.forward * 100f); // Sets the end of laser 100m in front of hand
            }
        }

        else if (Input.GetButtonUp(teleportButtonName) == true) // The moment the teleport button is released!
        {
            // Before I move the rig, calculate the XrRig position offset from the player's head
            Vector3 offset = xrRig.position - headset.position;
            offset.y = 0; // Zero-out the vertical component of offset (don't want our head in the ground)

            xrRig.position = teleportPosition + offset; // Move the XR rig transform to the telpoert posn
            
            laserLine.enabled = false; // Turn on the laser 
        }
    }
}
