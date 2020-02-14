using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Test : DefaultTrackableEventHandler
{
    protected override void OnTrackingFound()
    {
        Debug.Log("Bam");
    }
}
