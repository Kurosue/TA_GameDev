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
    public AudioSource _magnetPick;
    public AudioSource _truckJalan;
    public AudioSource _tabrak;
    public AudioSource _Jalan;
    public GameObject _HUD;
    private float _SoundTiemr = 0f;
    void Update()
    {
        _SoundTiemr += Time.deltaTime;
        if(_SoundTiemr >= 4.5f)
        {
            _truckJalan.Play();
        }
        if(_playerHP < 2){
            _timer += Time.deltaTime;

            if (_timer >= _timeDuration)
            {
            _playerHP = 2;
            _timer = 0f;
            }      
            }

        // Update Volume
        _truckJalan.volume = (PlayerPrefs.GetFloat("SFXVol") * 0.4f) / 0.4f;
        _magnetPick.volume = (PlayerPrefs.GetFloat("SFXVol") * 0.4f) / 0.4f;
        _tabrak.volume = (PlayerPrefs.GetFloat("SFXVol") * 0.4f) / 0.4f;
        _Jalan.volume = (PlayerPrefs.GetFloat("SFXVol") * 0.4f) / 0.4f;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            _tabrak.Play();
            Destroy(other.gameObject);
            _trackScript.kecepatan = 0.75f;
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
            _magnetPick.Play();
            _HUD.SetActive(true);
            transform.GetChild(0).GetComponent<ColliderOnlyForCoin>().MagnetCollision();
        }
    }

    void ObstacleCollision()
    {
        _playerHP--;
        if (_playerHP <= 0)
        {
            PlayerPrefs.SetInt("Gas", 0);
            PlayerPrefs.Save();
        }
    }
}
