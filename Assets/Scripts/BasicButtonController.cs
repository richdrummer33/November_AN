using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicButtonController : MonoBehaviour
{
    public Transform button; // The transform we are moving

    public Transform closedPosition; // Where to move the button

    public delegate void ButtonPushedEvent(); // Declaring the delegate
    public ButtonPushedEvent OnButtonPushed; // Instance of the delegate

    // Hand (or other object w/rb and collider) ENTERS
    private void OnTriggerEnter(Collider other)
    {
        button.position = closedPosition.position; // Change the position of button to the closedPosition

        // Button actions go here
        GetComponent<AudioSource>().Play();

        OnButtonPushed(); // When pushed, run all of the methods/functions that are subscribed to this delegate
    }

    // Hand (or other object w/rb and collider) LEAVES
    private void OnTriggerExit(Collider other)
    {
        button.position = transform.position;
    }
}
