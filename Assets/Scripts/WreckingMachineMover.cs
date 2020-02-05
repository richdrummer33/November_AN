using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingMachineMover : MonoBehaviour
{
    public LeverController forwardBackLever, leftRightLever, rotateControl;

    public float maxSpeed = 5f; // Meters per second

    public float maxRotateSpeed = 40f; // Degrees per seconf

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(forwardBackLever.GetNormalizedControlValue()) > 0.05f)
        {
            transform.position = transform.position + Vector3.forward * forwardBackLever.GetNormalizedControlValue() * Time.deltaTime * maxSpeed;
        }

        if (Mathf.Abs(leftRightLever.GetNormalizedControlValue()) > 0.05f)
        {
            transform.position = transform.position + Vector3.right * leftRightLever.GetNormalizedControlValue() * Time.deltaTime * maxSpeed;
        }

        if(Mathf.Abs(rotateControl.GetNormalizedControlValue()) > 0.05f)
        {
            transform.Rotate(Vector3.up, rotateControl.GetNormalizedControlValue() * Time.deltaTime * maxRotateSpeed);
        }
    }
}
