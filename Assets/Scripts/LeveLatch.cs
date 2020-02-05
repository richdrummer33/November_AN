using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Detect when the lever enters the trigger collider, and add force to hold it in position
public class LeveLatch : MonoBehaviour
{
    public float latchForce = 10f;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name + " Just collided");

        if (other.transform.parent == transform.parent) // Add force to the lever arm
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.right * latchForce);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
