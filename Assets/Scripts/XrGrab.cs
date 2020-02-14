using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrGrab : MonoBehaviour
{
    #region Variables

    public GameObject collidingObject; // the object that we are touching

    public GameObject heldObject; // To remember what obj we are holding, so we know what to release

    public Animator handAnimator; // Refer to animator on hand game object/model

    public string gripAxisName;

    public string triggerAxisName; // For interacting

    bool handIsClosed = false;

    bool triggerIsPulled = false;

    #endregion

    #region Collisions

    // This function fires only at the instant the collision occurrs
    private void OnTriggerEnter(Collider other) // This code will run when this object collides with other <rigidboies witch colliders>
    {
        if (other.tag == "Grabbable" || other.tag == "Control")
        {
            collidingObject = other.gameObject; // Take note of what I am touching, so that when I click the left mouse button, I grab that object
        }
    }

    // This function fires only at the instant the collision stops occurring
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == collidingObject)
        {
            collidingObject = null; // Empty the bucket (i.e. "Forget" what we're touching)
        }
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        #region Grab n Release

        if (Input.GetAxis(gripAxisName) > 0.5f && handIsClosed == false) // Check for left-mouse click - if touching object, then grab it
        {
            if (handAnimator != null)
            {
                handAnimator.SetBool("Closed", true);
            }

            // Attempt to grab colliding object
            if (collidingObject != null) // If we are in fact colliding with an object
            {
                Grab(); // Call the grab function (i.e. "run" the function)
            }

            handIsClosed = true; // I *just* closed my hand 
        }
        else if (Input.GetAxis(gripAxisName) < 0.5f && handIsClosed == true) // Realeased mouse button - so attempt release of held object 
        {
            if (handAnimator != null)
            {
                handAnimator.SetBool("Closed", false);
            }

            if (heldObject != null) // We're holding something
            {
                Release();
            }

            handIsClosed = false; // I *just* opened my hand
        }

        #endregion

        #region Interact

        if(Input.GetAxis(triggerAxisName) > 0.5f && triggerIsPulled == false) // If pulling trigger, then interact
        {
            if(heldObject != null) // Check that we're actually holding something before attempting interact
            {
                if(heldObject.GetComponent<InteractableObject>() != null) // Check if is an interactable obj (if it has a script that inherits from InteractableObject)
                {
                    heldObject.GetComponent<InteractableObject>().Interact(); // Start the interaction
                }

                //heldObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver); // Attempt to call/run the Interact() method/function on the held object
            }

            triggerIsPulled = true; // I just* pulled the trigger
        }
        else if (Input.GetAxis(triggerAxisName) < 0.5f && triggerIsPulled == true) // If trigger releases, stop interact
        {
            if(heldObject != null)
            {
                if(heldObject.GetComponent<InteractableObject>() != null) // Check if is an interactable obj (if it has a script that inherits from InteractableObject)
                {
                    heldObject.GetComponent<InteractableObject>().StopInteract(); 
                }

                //heldObject.SendMessage("StopInteract", SendMessageOptions.DontRequireReceiver); // Attempt to call/run the the StopInteract() method/function on the held object
            }

            triggerIsPulled = false; // I just* released the trigger
        }

        #endregion
    }

    #region Grab and Release

    void Grab()
    {
        FixedJoint myJoint = gameObject.AddComponent<FixedJoint>(); // Add fixed joint component to this hand

        myJoint.connectedBody = collidingObject.GetComponent<Rigidbody>(); // The rigidbody of the object we are colliding with (connecting the joint)

        myJoint.breakForce = 1000f; // Values can be adjusted to your liking

        myJoint.breakTorque = 1000f; // Values can be adjusted to your liking

        if (collidingObject.tag != "Control")
        {
            collidingObject.transform.SetParent(transform); // Now hand influences velocity of held object more directly (prevents physics jitter)
        }

        heldObject = collidingObject; // "Remember" what holding so can release
    }

    void Release()
    {
        Destroy(GetComponent<FixedJoint>());

        if (heldObject.tag != "Control")
        {
            heldObject.transform.SetParent(null); // Make it parentless
        }

        heldObject = null;
    }

    // This method fires immediately when joint breaks
    private void OnJointBreak(float breakForce)
    {
        if (heldObject.tag != "Control")
        {
            heldObject.transform.SetParent(null); // Make it stop tracking the velocity of our hand
        }

        heldObject = null; // Forget what holding
    }

    #endregion
    
    #region Basic Grab Methods

    // Below is the old parenting grab method
    void BasicGrab()
    {
        collidingObject.GetComponent<Rigidbody>().isKinematic = true; // To prevent object from being influenced by external 
        collidingObject.transform.SetParent(this.transform); // So that collidingObject follows the motion of the 
        heldObject = collidingObject;
    }

    // Below is the old parenting grab method
    void BasicRelease()
    {
        heldObject.GetComponent<Rigidbody>().isKinematic = false; // Responds to forces incl gravity
        heldObject.transform.SetParent(null); // Make it parentless 
        heldObject = null; // "Forget" what we were holding
    }

    #endregion
}
