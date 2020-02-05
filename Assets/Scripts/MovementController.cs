using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public LeverController forwardBackLever;

    public float maxSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * forwardBackLever.GetNormalizedControlValue() * Time.deltaTime * maxSpeed;
    }
}
