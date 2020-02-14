using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        
        // Common logic for all interactables can go here 
        // For example, sound effects play when interact starts
    }

    public virtual void StopInteract()
    {
        Debug.Log("Stopped interacting with " + gameObject.name);

        // Common logic for all interactables can go here 
        // For example, sound effects play when interact ends
    }
}
