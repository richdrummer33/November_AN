using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    Vector3 startPos;
    Rigidbody rb;

    public BasicButtonController resetButton;

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // Taking note where this cube started 

        rb = GetComponent<Rigidbody>(); // Get its own rigidbody

        resetButton.OnButtonPushed += ResetCube; // "+= <MethodName>" subscribes <MethodName> to the delegate in the button controller

        source = GetComponent<AudioSource>();
    }

    void ResetCube() // To bring cube back to original position
    {
        transform.position = startPos; // i.e. immediately move back to orig pos

        rb.velocity = Vector3.zero; // MAke it stop!!! 
        rb.angularVelocity = Vector3.zero; // Stahp spinning!
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 1f) // Over 1 meter per second (threshold)
        {
            Debug.Log("Velocity = " + collision.relativeVelocity.magnitude);

            source.volume = collision.relativeVelocity.magnitude / 8f; // 4f is a scaling factor

            source.pitch = 1f + collision.relativeVelocity.magnitude / 8f;

            source.Play(); // PLay the sound defined in the AudioSource component
        }
    }
}

