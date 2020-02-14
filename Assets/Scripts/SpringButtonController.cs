using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringButtonController : MonoBehaviour
{
    public GameObject button;

    public List<Rigidbody> cubeRbs = new List<Rigidbody>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == button) // Check that it's the button that collided with this 
        {
            GetComponent<AudioSource>().Play(); // play a sound (or some other feature you want to implement)

            for (int index = 0; index < cubeRbs.Count; index++)
            {
                cubeRbs[index].AddForce(cubeRbs[index].transform.right * 20f, ForceMode.Impulse);
            }
        }
    }
}
