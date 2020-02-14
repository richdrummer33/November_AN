using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePaintBrush : InteractableObject
{
    public GameObject paintTrailPrefab; // Need a prefab to paint!

    GameObject currentPaintTrail; // the trail that's currently getting painted

    public Renderer brushRenderer; // The mesh renderer on the brush cube

    Material paintMaterial; // Stores the material (color) that we are painting with

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "Paint") // Check what we hit is actually paint
        {
            paintMaterial = collision.gameObject.GetComponent<Renderer>().material; // Get the paint color/mat from the paint's renderer

            brushRenderer.material = paintMaterial; // Apply the 
        }
    }

    // Upon Interact, start painting!
    public override void Interact()
    {
        base.Interact(); // Run (call) the inherited (base/originator) method

        if(currentPaintTrail == null) // Check that we're not already painting, before instantiating a new paint trail
        {
            currentPaintTrail = Instantiate(paintTrailPrefab, brushRenderer.transform.position, Quaternion.identity, brushRenderer.transform); // Making a clone of the paint prefab, and placiong on the brush's position (as child of the brush)

            currentPaintTrail.GetComponent<Renderer>().material = paintMaterial; // Apply the paint material to the instance of the paint trail
        }
    }

    // Upon StopInteract, stop painting! 
    public override void StopInteract()
    {
        base.StopInteract();

        if(currentPaintTrail != null) // Check that we are in fact painting first
        {
            currentPaintTrail.transform.parent = null; // Un-child the paint trail (make it parentless) - will stop following the brush!

            currentPaintTrail = null; // Forget the currentPaintTrail, since we're done with it - want to be able to make another one!
        }
    }
}
