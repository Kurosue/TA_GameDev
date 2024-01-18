using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject _gameOver;
    public AudioSource _musik;

    void Update(){
        _musik.volume = (PlayerPrefs.GetFloat("MusVol") * 0.5f) / 0.5f;
    }
    public void PlayAgain()
    {
        PlayerPrefs.SetInt("Gas", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}