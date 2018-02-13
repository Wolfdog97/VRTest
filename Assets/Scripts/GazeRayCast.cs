using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this script will detact if you are looking at something
// by shooting a raycast out in front of the camera
public class GazeRayCast : MonoBehaviour {

     float timeLookedAt;

	// Update is called once per frame
	void Update () {
        // SHOOTING A RAYCAST
        // 1. construct a "Ray" object
        Ray myRay = new Ray(transform.position, transform.forward);

        // 2. declare a Raycast object, to store the raycast hit info
        RaycastHit myRayHit = new RaycastHit(); // this isa blank variable, will fill with data later 

        // 3. visulaize raycast in the editor
        Debug.DrawRay(myRay.origin, myRay.direction * 100f, Color.yellow);

        // 4. actually shoot the raycast now!
        if(Physics.Raycast( myRay, out myRayHit, 100f))
        {
            timeLookedAt += Time.deltaTime;
            
            if(timeLookedAt > 1f)
            {
                //once we hit something, we should spin it, to show that we're looking at 
                myRayHit.transform.Rotate(0f, 90f * Time.deltaTime, 0f); //myRayHit.transform =  the thing the raycast hit
            }

        }
        else
        {
            timeLookedAt = 0f;
        }

    }
}
