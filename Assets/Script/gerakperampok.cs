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

    public  void MoveToForwardPosition()
    {
        // Move towards the forward position
        transform.position = Vector3.MoveTowards(transform.position, forwardPosition.position, moveSpeed * Time.deltaTime);

        // Check if reached the forward position with a small threshold
        if (Vector3.Distance(transform.position, forwardPosition.position) < 0.01f)
        {
            // If reached, return to the original position
            ReturnToOriginalPosition();
        }
    }

    public void ReturnToOriginalPosition()
    {
        // Return to the original position
        transform.position = Vector3.MoveTowards(transform.position, originalPosition.position, returnSpeed * Time.deltaTime);

        // Check if reached the original position with a small threshold
        if (Vector3.Distance(transform.position, originalPosition.position) < 0.01f)
        {
            isMovingForward = false;
        }
    }
}

