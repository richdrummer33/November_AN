using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody thisRigidbody;

    public float forceModifier = 5f;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0) // Attempt raycast
        {
            Vector2 touchPoint = Input.GetTouch(0).position; // Determine where on screen finger touched on screen 2D
            Vector3 raycastOrigin = Camera.current.ScreenToWorldPoint(new Vector3(touchPoint.x, touchPoint.y, Camera.current.nearClipPlane)); // Translate the position on the screen to a 3D position in Unity (in the scene)
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            RaycastHit raycastHitInfo;

            if(Physics.Raycast(ray, out raycastHitInfo))
            {
                //Vector3 force = raycastHitInfo.point - transform.position;

                //thisRigidbody.AddForce(force * forceModifier);
                transform.position = raycastHitInfo.point;
            }
        }
    }
}
