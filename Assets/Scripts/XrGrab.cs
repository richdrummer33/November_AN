using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrGrab : MonoBehaviour
{
    public GameObject collidingObject; // the object that we are touching

    public GameObject heldObject; // To remember what obj we are holding, so we know what to release

    public Animator handAnimator; // Refer to animator on hand game object/model

    public string gripAxisName;

    bool handIsClosed = false;

    // This function fires only at the instant the collision occurrs
    private void OnTriggerEnter(Collider other) // This code will run when this object collides with other <rigidboies witch colliders>
    {
        collidingObject = other.gameObject; // Take note of what I am touching, so that when I click the left mouse button, I grab that object
    }

    // This function fires only at the instant the collision stops occurring
    private void OnTriggerExit(Collider other)
    {
        collidingObject = null; // Empty the bucket (i.e. "Forget" what we're touching)
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
    }

    void Grab()
    {
        collidingObject.GetComponent<Rigidbody>().isKinematic = true; // To prevent object from being influenced by external forces

        collidingObject.transform.SetParent(this.transform); // So that collidingObject follows the motion of the hand

        heldObject = collidingObject; // "Remember" what holding so can release
    }

    void Release()
    {
        heldObject.GetComponent<Rigidbody>().isKinematic = false; // Responds to forces incl gravity

        heldObject.transform.SetParent(null); // Make it parentless 

        heldObject = null; // "Forget" what we were holding
    }
}
