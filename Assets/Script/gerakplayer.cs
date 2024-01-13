using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class gerakplayer : MonoBehaviour
{
    public GameObject truk;
    public int score = 0;
    public float kecepatan = 5f;
    public float leftBound; // Batas kiri
    public float rightBound; // Batas kanan
    Rigidbody2D rb;
    public bool tabrak;
    public LayerMask targetLayer;
    public Transform deteksiTabrak;
    public float jangkauan;
    float timerskor = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        tabrak = Physics2D.OverlapCircle(deteksiTabrak.position, jangkauan, targetLayer);
        if (tabrak){
            Invoke("Disableblink", 0f);
            Invoke("Enableblink", 0.01f);
    }
        hitungskor();
        gerakhorizontal();  
    }
    void gerakhorizontal(){
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f);
        rb.velocity = new Vector2(movement.x * kecepatan, rb.velocity.y);   
        float clampedX = Mathf.Clamp(rb.position.x, leftBound, rightBound); 
        rb.position = new Vector2(clampedX, rb.position.y);
    }
    void hitungskor(){
        timerskor += Time.deltaTime;
        if (timerskor >= 0.1){
            score++;
            timerskor = 0;
        }
    }
    void Enableblink(){
        truk.SetActive(true);
    }
    void Disableblink(){
        truk.SetActive(false);
    }
}
