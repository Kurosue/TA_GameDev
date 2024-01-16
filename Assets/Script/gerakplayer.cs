using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class gerakplayer : MonoBehaviour
{
    public float kecepatan = 5f;
    public float leftBound; // Batas kiri
    public float rightBound; // Batas kanan
    Rigidbody2D rb;
    public GameManager _gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(_gameManager._gas)
        {    
            gerakhorizontal();  
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
    void gerakhorizontal(){
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f);
        rb.velocity = new Vector2(movement.x * kecepatan, rb.velocity.y);   
        float clampedX = Mathf.Clamp(rb.position.x, leftBound, rightBound); 
        rb.position = new Vector2(clampedX, rb.position.y);

    }
}
