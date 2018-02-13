using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{

    private bool moveRight = true;
    public float moveSpeed = 1f;
    public float posLimit = 6;
    public float negLimit = -6;

    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (transform.position.x >= posLimit)
        {
            moveRight = false;
        }

        if (transform.position.x <= negLimit)
        {
            moveRight = true;
        }
    }


}
