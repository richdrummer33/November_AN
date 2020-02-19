using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Apply this script to the camera for the mirror
//[ExecuteInEditMode]
public class MirrorCameraReflect : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 phoneToMirror = transform.position - Camera.main.transform.position;

        Vector3 reflectDirection = Vector3.Reflect(phoneToMirror, -transform.parent.forward);

        transform.rotation = Quaternion.LookRotation(reflectDirection);
    }
}
