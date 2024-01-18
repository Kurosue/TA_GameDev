using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderOnlyForCoin : MonoBehaviour
{

    public float _timer = 0f;
    private bool _magnet = false;
    public GameManager _gameManager;
    Vector2 _defaultSize = new Vector2(0.01429209f, 0.0200274f);
    Vector2 _defaultOffset = new Vector2(6.697513e-05f, 0.2854659f);
    BoxCollider2D CollCoin;
    AudioSource _coinpick;
    public AudioSource _coinSFX;
    void Start()
    {
        _coinpick = GetComponent<AudioSource>();
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
        _coinSFX.volume = PlayerPrefs.GetFloat("SFXVol");
        if (other.CompareTag("Coin"))
        {
            other.GetComponent<CoinMove>()._tarik = true;
            _coinpick.Play();
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
