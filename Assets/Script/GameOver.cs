using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject _gameOver;
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}