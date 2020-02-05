using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    HingeJoint myJoint;

    // Start is called before the first frame update
    void Start()
    {
        myJoint = GetComponent<HingeJoint>();
    }

    // Returns the normalized angle of the joint 
    public float GetNormalizedControlValue()
    {
        float normAngle = myJoint.angle / myJoint.limits.max; // Calculates a number between -1 and +1

        return normAngle;
    }
}
