using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public float _playerHP = 2f;
    public tracka _trackScript;
    private float _timer = 0f;
    private float _timeDuration = 5f;
    public GameManager _gameManager;
    public GameObject _magnetHUD;
    AudioSource _audio;
    public AudioClip _magnetPick;
    public GameObject _HUD;
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.clip = _magnetPick;
    }
    void Update()
    {
        if(_playerHP < 2){
            _timer += Time.deltaTime;

            if (_timer >= _timeDuration)
            {
            _playerHP = 2;
            _timer = 0f;
            }      
            }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            _trackScript.kecepatan = 0.15f;
            ObstacleCollision();
            GameObject[] perampoks = GameObject.FindGameObjectsWithTag("Perampok");

            foreach (GameObject perampok in perampoks)
            {
                perampok.GetComponent<gerakperampok>().isTrigger();
            }


        }

        if(other.CompareTag("Magnet"))
        {
            Destroy(other.gameObject);
            _audio.Play();
            GameObject targetObject = GameObject.FindWithTag("MagnetTiemr");
            if(targetObject == null){
                Instantiate(_magnetHUD, new Vector3(0f, 0f,0f), Quaternion.identity, _HUD.transform);
            }
            transform.GetChild(0).GetComponent<ColliderOnlyForCoin>().MagnetCollision();
        }
    }

    void ObstacleCollision()
    {
        _playerHP--;
        if (_playerHP <= 0)
        {
            _gameManager._gas = false;
        }
    }
}
