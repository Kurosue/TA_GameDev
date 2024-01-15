using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerakperampok: MonoBehaviour
{
    public Transform originalPosition;
    public Transform forwardPosition;
    public float moveSpeed = 0.8f;
    public float returnSpeed = 0.5f;

    private bool isMovingForward = false;

    void Start()
    {
        // Start by moving all "Perampok" objects to the return position
        MoveAllPerampokObjects(originalPosition.position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") && other.CompareTag("Player"))
        {
            isMovingForward = true;
        }
    }

    void Update()
    {
        if (isMovingForward)
        {
            MoveAllPerampokObjects(forwardPosition.position);
        }
    }

    void MoveAllPerampokObjects(Vector3 targetPosition)
    {
        // Find all GameObjects with the "Perampok" tag
        GameObject[] perampokObjects = GameObject.FindGameObjectsWithTag("Perampok");

        // Move each "Perampok" GameObject
        foreach (GameObject perampokObject in perampokObjects)
        {
            MovePerampokObject(perampokObject.transform, targetPosition);
        }
    }

    void MovePerampokObject(Transform perampokTransform, Vector3 targetPosition)
    {
        // Move towards the target position
        perampokTransform.position = Vector3.MoveTowards(perampokTransform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if reached the target position with a small threshold
        if (Vector3.Distance(perampokTransform.position, targetPosition) < 0.01f)
        {
            // If reached, return to the original position
            ReturnToOriginalPosition(perampokTransform);
        }
    }

    void ReturnToOriginalPosition(Transform perampokTransform)
    {
        // Return to the original position
        perampokTransform.position = Vector3.MoveTowards(perampokTransform.position, originalPosition.position, returnSpeed * Time.deltaTime);

        // Check if reached the original position with a small threshold
        if (Vector3.Distance(perampokTransform.position, originalPosition.position) < 0.01f)
        {
            isMovingForward = false;
        }
    }
}
