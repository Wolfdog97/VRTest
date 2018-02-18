using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGaze : MonoBehaviour {

    float timeLookedAt;

    [Range(1f, 120f)]
    public float threshold;

    void Update()
    {
        //1. am I within the Camera's field of view? / middle of the screen?
        // Get Vector from camera to object
        Vector3 fromCameraToMe = transform.position - Camera.main.transform.position;

        // compare that vector to camera's foward firection, and measure the angle
        float angle = Vector3.Angle(Camera.main.transform.forward, fromCameraToMe.normalized);

        //if that angle is less than X, then that object is within the vision cone
        if (angle < 10f) //if within 10 degrees of middle of screen, then... etc etc
        {
            Debug.Log("I'm being looked at!");

            timeLookedAt += Time.deltaTime;
            if(timeLookedAt > threshold)
            {
                gameObject.SetActive(false);
            }
        }
        // if you wanted to make sure that there's nothing blocking our view
        // you would add a raycast check here, beteen Camera.main and this.transform
        // (see GazeRaycast.cs for that kind of stuff

    }
}
