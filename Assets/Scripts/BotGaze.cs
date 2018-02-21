using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotGaze : MonoBehaviour {


    float timeLookedAt;

    [Range(1f, 120f)]
    public float threshold;

    public float degrees = 10f;

    public GameObject explosion;

    public List<GameObject> lightsToTurnOn;
    public List<GameObject> lightsToTurnOff;

    void Update()
    {
        //1. am I within the Camera's field of view? / middle of the screen?
        // Get Vector from camera to object
        Vector3 fromCameraToMe = transform.position - Camera.main.transform.position;

        // compare that vector to camera's foward firection, and measure the angle
        float angle = Vector3.Angle(Camera.main.transform.forward, fromCameraToMe.normalized);

        //if that angle is less than X, then that object is within the vision cone
        if (angle < degrees) //if within 10 degrees of middle of screen, then... etc etc
        {
            Debug.Log("I'm being looked at!");

            timeLookedAt += Time.deltaTime;
            if (timeLookedAt > threshold)
            {
                Destroy(gameObject);
                GameObject explode = Instantiate(explosion, transform.position, transform.rotation);

                foreach (GameObject thisObject in lightsToTurnOff)
                {
                    thisObject.SetActive(false);
                }

                foreach (GameObject thisObject in lightsToTurnOn)
                {
                    thisObject.SetActive(true);
                }
            }
        }
    }
}
