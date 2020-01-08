using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLauncher : MonoBehaviour
{
    public GameObject fireballPrefab; // Holds a reference to the prefab I want to launch

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject fireballClone; // Create a temp variable to hold the cloned prefab (i.e. the "instance")
            fireballClone = Instantiate(fireballPrefab, transform.position, transform.rotation); // Clone the prefab. This function returns the object it creates (GameObject).

            fireballClone.GetComponent<Rigidbody>().AddForce(transform.forward * 50f, ForceMode.Impulse);

            Destroy(fireballClone, 10f); // destroyed after 10 seconds
        }
    }
}
