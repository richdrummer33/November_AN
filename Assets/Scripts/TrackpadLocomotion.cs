using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackpadLocomotion : MonoBehaviour
{
    public string horizontalAxisInputName, verticalAxisInputName; // 2 string (text) variables! Define name in the inspector!

    public Transform xrRig; // This is what we're moving

    public float speed = 3f;

    public LayerMask raycastLayerMask; // This defines what colliders will be detected by the Raycast. This can be set up in the inspector.

    // Update is called once per frame
    void Update()
    {
        float trackpadX = Input.GetAxis(horizontalAxisInputName);
        float trackpadY = Input.GetAxis(verticalAxisInputName);

        Vector3 forward = trackpadY * transform.forward; // The amount forward/back we are going to move
        Vector3 right = trackpadX * transform.right; // The amout right/left we are going to move

        // Make sure we dont float up or sink down (as our controller is tilted up and down)
        forward.y = 0f; // I.e. velocity (movement) in the vertical direction will be 0 
        right.y = 0f;

        Vector3 direction = forward + right;

        xrRig.transform.position = xrRig.transform.position + direction * Time.deltaTime * speed; // Apply movement to the rig!

        float height = GetGroundHeight(); // Ask the calculator (e.g. my method) "what's the ground height?" I.e. get the floor height by calling the GetGroundHeight method

        Vector3 rigPosition = xrRig.position; // Temporarilyt store the rig's current position so that we can edit it
        rigPosition.y = height;
        xrRig.transform.position = rigPosition;
    }

    // This function will determine the height of the ground and return that value (a floating point number which represents the y-value or height of ground)
    float GetGroundHeight()
    {
        float floorHeight; // Variable to store the height

        RaycastHit raycastHitInfo; // Store the info about what collider was hit by raycast (hit point)

        Physics.Raycast(Camera.main.transform.position, Vector3.down, out raycastHitInfo, Mathf.Infinity, raycastLayerMask); // detect position on collider below our head (presumably ground)
        Debug.DrawLine(Camera.main.transform.position, raycastHitInfo.point);

        floorHeight = raycastHitInfo.point.y; // Get the height (y-value) of the position that was hit

        return floorHeight;
    }
}
