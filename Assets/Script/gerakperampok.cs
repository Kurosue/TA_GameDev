using System.Collections;
using UnityEngine;

public class gerakperampok : MonoBehaviour
{
    public Transform originalPosition;
    public Transform forwardPosition;
    public float moveSpeed = 0.8f;
    public float returnSpeed = 0.5f;
    public float delayTime = 3f; // Waktu penundaan di forward position

    private bool isMovingForward = false;

    void FixedUpdate()
    {
        if (isMovingForward)
        {
            MoveToForwardPosition();
        }
        else
        {
            Vector2 a = transform.position;
            Vector2 b = originalPosition.position;
            transform.position = Vector2.Lerp(a, b, returnSpeed);
        }
    }

    public void isTrigger()
    {
        isMovingForward = true;
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

            // Start a coroutine to wait for a delay before returning to the original position
            StartCoroutine(WaitAndReturnToOriginalPosition());
        }
    }

    IEnumerator WaitAndReturnToOriginalPosition()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayTime);

        // Start returning to the original position
        isMovingForward = false;
    }
}



