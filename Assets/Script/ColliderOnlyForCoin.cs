using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderOnlyForCoin : MonoBehaviour
{

    private float _timer = 0f;
    private bool _magnet = false;
    private float _magnetForce = 10f;
    public GameManager _gameManager;
    Vector2 _defaultSize = new Vector2(0.01429209f, 0.0200274f);
    Vector2 _defaultOffset = new Vector2(6.697513e-05f, 0.2854659f);
    BoxCollider2D CollCoin;
    
    void Start()
    {
        CollCoin = GetComponent<BoxCollider2D>();
        CollCoin.size = _defaultSize;
        CollCoin.offset = _defaultOffset;
    }

    void Update()
    {
        if(_magnet)
        {
            _timer += Time.deltaTime;
            if(_timer >= 15f)
            {
                BackToSize();
                _magnet = false;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Rigidbody2D coinRigidbody = other.GetComponent<Rigidbody2D>();
            Vector2 direction = transform.position - other.transform.position;
            direction.Normalize();
            coinRigidbody.AddForce(direction * _magnetForce, ForceMode2D.Impulse);
            _gameManager._coinCount += 1f;
        }
    }

    public void MagnetCollision()
    {
        CollCoin = GetComponent<BoxCollider2D>();
        CollCoin.size = new Vector2(0.2053223f, 0.05887538f);
        CollCoin.offset = new Vector2(0.0003538094f, 0.3048899f);
        _timer = 0f;
        _magnet = true;
    }

    private void BackToSize()
    {
        CollCoin = GetComponent<BoxCollider2D>();
        CollCoin.size = _defaultSize;
        CollCoin.offset = _defaultOffset;
        _timer = 0f;
    }
}
