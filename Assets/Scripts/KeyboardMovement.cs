using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public float moveSpeed = 30f;

    public float rotationSpeed = 60f;

    public float speedMultiplier = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame (in VR 90x per second)
    void Update()
    {
        #region Keyboard Movement

        float speed; // The speed that we'll apply to the actual movement 

        if(Input.GetKey(KeyCode.LeftShift)) 
        {
            speed = moveSpeed * speedMultiplier; // 2x the default move speed
        }
        else
        {
            speed = moveSpeed;
        }

        if (Input.GetKey(KeyCode.W)) // If statement checks for true or false - if true, it will run the code contained between { } 
        {
            this.transform.position = this.transform.position + transform.forward * Time.deltaTime * speed; // Move forwards
        }
        else if( Input.GetKey(KeyCode.S) ) // Move backwards --> if not pressing the "W" key while pressing hte "S" key
        {
            this.transform.position = this.transform.position - transform.forward * Time.deltaTime * speed; 
        }

        if(Input.GetKey(KeyCode.A)) // Move Left
        {
            this.transform.position = this.transform.position - transform.right * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.D)) // Move Right
        { 
            this.transform.position = this.transform.position + transform.right * Time.deltaTime * speed;
        }

        #endregion

        #region Mouse Movement

        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime, Space.World); // Rotate/look left/right

        transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime, Space.Self); // Rotate/look up/down

        #endregion
    }
}