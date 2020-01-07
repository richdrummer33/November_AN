using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColliderTesting : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.gameObject.name + " has trigger-detected " + other.name);
    }
}
