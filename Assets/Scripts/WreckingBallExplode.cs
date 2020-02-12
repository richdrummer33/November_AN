using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallExplode : MonoBehaviour
{
    ParticleSystem explodeParticles;
    AudioSource source;

    private void OnCollisionEnter(Collision collision)
    {
        // optional: Check a tag before making explosion
        if (!explodeParticles.isPlaying && collision.transform.parent != transform.parent)
        {
            explodeParticles.Play();
            source.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        explodeParticles = GetComponentInChildren<ParticleSystem>(); // fetch the component from the child game object
        source = GetComponent<AudioSource>();
    }
}
