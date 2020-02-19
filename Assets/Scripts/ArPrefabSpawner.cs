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

                    RotateFacePlayer();
                }
            }
        }
    }

    void RotateFacePlayer()
    {
        Vector3 playerDirection = Camera.main.transform.position - prefabInstance.transform.position; // Direction pointing from the mirror prefab to the phone/player (camera)

        Quaternion rotationTowardsPlayer = Quaternion.FromToRotation(prefabInstance.transform.forward, playerDirection); // Get a "rotation" (quaternion, which describes a rotation) that we can apply to the mirror

        Vector3 verticalAngularRotation = new Vector3(prefabInstance.transform.eulerAngles.x, rotationTowardsPlayer.eulerAngles.y, prefabInstance.transform.eulerAngles.z); // Creating a Vector3 that contains the angeles in degrees (i.e. euler angles) 

        prefabInstance.transform.rotation = Quaternion.Euler(verticalAngularRotation); // Finally applying the new rotation to the prefab instance
    }
}
