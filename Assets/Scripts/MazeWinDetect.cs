using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWinDetect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            GetComponent<AudioSource>().Play();

            other.GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Impulse); // Launch the ball for fun

            Destroy(other.gameObject, 5f); // Alternative: move ball back to original position after 5 seconds (so can replay game)
        }
    }
}
