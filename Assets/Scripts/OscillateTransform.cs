using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillateTransform : MonoBehaviour
{

    public float oscillationSpeed = 1f;
    public float oscFudgeX = 1.25f;
    public float oscFudgeY = 1.5f;
    public float oscFudgeZ = 1.3f;
    public float oscillationAmplitude = 0.1f;
    float flickerSeed;
    public float intensityMultiplier = 0.9f;
    public float fadeRate = 5f;
    float seed;

    float minIntensity;
    float maxIntensity;
    float startIntensity;

    private int ct = 0;

    Light light;

    private void Start()
    {
        light = GetComponent<Light>();
        seed = Random.Range(0.6f, 0.8f);

        startIntensity = light.intensity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        minIntensity = startIntensity * intensityMultiplier;
        maxIntensity = startIntensity / intensityMultiplier;

        /*transform.position = new Vector3 (transform.position.x + Mathf.Sin (ct * oscillationSpeed / 50f + oscFudgeX) * Mathf.Cos (ct * oscillationSpeed / 50f) * oscillationAmplitude,
			transform.position.y + Mathf.Sin (ct * oscillationSpeed / 50f + oscFudgeY) * Mathf.Cos (ct * oscillationSpeed / 50f) * oscillationAmplitude,
			transform.position.z + Mathf.Sin (ct * oscillationSpeed / 50f + oscFudgeZ) * Mathf.Cos (ct * oscillationSpeed / 50f) * oscillationAmplitude);*/

        transform.position = new Vector3(transform.position.x + Mathf.Sin(ct * oscillationSpeed / 50f + oscFudgeX + seed) * oscillationAmplitude,
            transform.position.y + Mathf.Sin(ct * oscillationSpeed / 50f + oscFudgeY + seed) * oscillationAmplitude,
            transform.position.z + Mathf.Sin(ct * oscillationSpeed / 50f + oscFudgeZ + seed) * oscillationAmplitude);

        float noise = (Mathf.Abs(Mathf.Sin(Time.time * fadeRate)) + Mathf.Abs(Mathf.Sin(Time.time * fadeRate * seed + seed))) / Mathf.Sqrt(2f);

        light.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

        //transform.position.y += Mathf.Sin (ct * oscillationSpeed / 50f + oscFudgeY) * Mathf.Cos(ct * oscillationSpeed / 50f) * oscillationAmplitude;
        //transform.position.z += Mathf.Sin (ct * oscillationSpeed / 50f + oscFudgeZ) * Mathf.Cos(ct * oscillationSpeed / 50f) * oscillationAmplitude;
        ct++;
    }
}
