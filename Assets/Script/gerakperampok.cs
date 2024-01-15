using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerakperampok : MonoBehaviour
{
    public Transform originalPosition;
    public Transform forwardPosition;
    public float moveSpeed = 0.8f;
    public float returnSpeed = 0.5f;

    void FixedUpdate()
    {
        // Move towards the original position continuously (for example, when not triggered by collision)
        transform.position = Vector3.MoveTowards(transform.position, originalPosition.position, returnSpeed * Time.deltaTime);
    }

    public void MoveForward()
    {
        // Move towards the forward position
        transform.position = Vector3.MoveTowards(transform.position, forwardPosition.position, moveSpeed * Time.deltaTime);

        // Check if reached the forward position
        if (Vector3.Distance(transform.position, forwardPosition.position) < 0.01f)
        {
            // If reached, return to the original position
            ReturnToOriginalPosition();
        }
    }

    void ReturnToOriginalPosition()
    {
        // Return to the original position
        transform.position = Vector3.MoveTowards(transform.position, originalPosition.position, returnSpeed * Time.deltaTime);
    }
}

