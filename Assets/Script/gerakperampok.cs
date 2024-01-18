using System.Collections;
using UnityEngine;

public class gerakperampok : MonoBehaviour
{
    public Transform originalPosition;
    public Transform forwardPosition;
    public float moveSpeed;
    public float returnSpeed;
    public float delayTime; // Waktu penundaan di forward position
    private bool isMovingForward = false;
    public tracka speed;
    public Animator animator;
    void FixedUpdate()
    {
        // animator = GetComponent<Animator>();
        float Speed = speed.kecepatan; // gunakan speed langsung jika kecepatan sudah ada di komponen tersebut
        animator.SetFloat("Speed", Speed);

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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            animator.SetBool("IsJumping",true);
            Debug.Log("Enter");
        }
     }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            animator.SetBool("IsJumping",false);
            Debug.Log("Exit");
        }
    }
}



