using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Cube " + other.name + " was detected");

        GameManager.instance.IncrementScore(); // Count the score
    }
}
