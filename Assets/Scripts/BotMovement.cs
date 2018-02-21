using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour {

    public bool goingFoward = true;
    public float moveSpeed = 5;

	void Update () {
		if (goingFoward == true)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        } 
        if (goingFoward != true)
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (goingFoward == true)
        {
            goingFoward = false;
        }
        else if (goingFoward != true)
        {
            goingFoward = true;
        }
    }
}
