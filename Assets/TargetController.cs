using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetController : MonoBehaviour
{
    public int numHits = 0; // Variable here to record the number of times that this target was hit (score)

    public Text myUiText; // need var to referece the text object

    private void OnCollisionEnter(Collision collision) // Function to detect when this target is hit - should increment the score
    {
        numHits = numHits + 1; // Increment when collider is hit

        myUiText.text = "My Game Score: " + numHits;
    } 
}