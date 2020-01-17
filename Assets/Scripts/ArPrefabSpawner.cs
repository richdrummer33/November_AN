using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ArPrefabSpawner : MonoBehaviour
{
    ARRaycastManager raycastManager;

    public GameObject prefab; // This might be the maze game (as a prefab)

    GameObject prefabInstance; // Holds reference to the prefab that was instantiated (default is null)

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>(); // Automatically get it
    }

    // Update is called once per frame
    void Update()
    {
        if (prefabInstance == null) // Check that the object hasn't yet been instantiated *before* bothering to check inputs (screen touch)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) // Need to check that player is touching screen
            {
                Vector2 touchPoint = Input.GetTouch(0).position; // Position on the screen of phone (2 dimensional)

                List<ARRaycastHit> hitsInfo = new List<ARRaycastHit>(); // Stores info about what was hit

                if (raycastManager.Raycast(touchPoint, hitsInfo, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinBounds)) // Returns true if plane is hit
                {
                    Vector3 hitPosition = hitsInfo[0].pose.position;

                    prefabInstance = Instantiate(prefab, hitPosition, prefab.transform.rotation);
                }
            }
        }
    }
}
