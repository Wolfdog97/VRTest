using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR; // you need this line to use XR funtions

public class FallBackMouseLook : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //if VR is disabled, then move the camera up to 1.6m
        if (XRSettings.isDeviceActive == false)
        {
            transform.Translate(0f, 1.6f, 0f); //move upwards 1.6m to simulate a person's height
        }

        //set tracking space to Room Scale, even if we're using an Oculus in standing mode
        XRDevice.SetTrackingSpaceType(TrackingSpaceType.RoomScale);

        // if your game is running too slow, this will make it more pixelated and run faster
        XRSettings.renderViewportScale = 0.9f; // render at 90% if normal resolution
	}
	
	// Update is called once per frame
	void Update () {
        //fallback mouse look behavior if not connected to an HMD
        if (XRSettings.isDeviceActive == false)
        {
            // 1. Get mouse input values
            float mouseX = Input.GetAxis("Mouse X"); // horizontal mouse movemnt... if not moiving, == 0
            float mouseY = Input.GetAxis("Mouse Y"); // vertical mouse movemnt... if not moiving, == 0

            // 2. Rotate camera based on mouse values
            transform.Rotate(-mouseY * 300f * Time.deltaTime, mouseX * 300f * Time.deltaTime, 0f);

            // 3. unroll the camera, because it can still roll even tho Z-angle was 0.0f
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0f);
        }
        

    }
}
