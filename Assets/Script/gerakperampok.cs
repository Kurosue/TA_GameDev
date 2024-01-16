using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerakperampok : MonoBehaviour
{
    public Transform originalPosition;
    public Transform forwardPosition;
    public float moveSpeed = 0.8f;
    public float returnSpeed = 0.5f;

    private bool isMovingForward = false;
    private float returnDelay = 5f;
    private float returnTimer = 0f;


    void FixedUpdate()
    {
        Vector2 a = transform.position;
        Vector2 b = originalPosition.position;
        transform.position = Vector2.Lerp(a,b,returnSpeed);
    }

    public void isTrigger()
    {
            isMovingForward = true;
    }

    public void Update()
    {
        if (isMovingForward)
        {
            MoveToForwardPosition();
        }
    }

    public void MoveToForwardPosition()
    {
        // Move towards the forward position
        transform.position = Vector3.MoveTowards(transform.position, forwardPosition.position, moveSpeed * Time.deltaTime);

        // Check if almost at the forward position
        if (Vector3.Distance(transform.position, forwardPosition.position) < 0.01f)
        {
            // If almost at the forward position, set the position directly to avoid overshooting
            transform.position = forwardPosition.position;

            // Start returning to the original position
            isMovingForward = false;
        }
    }

    public void ReturnToOriginalPosition()
    {
        // Move towards the original position
        transform.position = Vector3.MoveTowards(transform.position, originalPosition.position, returnSpeed * Time.deltaTime);

        // Check if almost at the original position
        if (Vector3.Distance(transform.position, originalPosition.position) < 0.01f)
        {
            // If almost at the original position, set the position directly to avoid overshooting
            transform.position = originalPosition.position;

            // Stop returning to the original position
            isMovingForward = false;
        }
    }

}

