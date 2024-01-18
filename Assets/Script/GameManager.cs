using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text _scoreText;
    public Text _coinText;

    private float _score = 0f;
    private float _hiScore = 0f;

    public tracka _trackScript;
    public float _coinCount = 0f;

    public bool _gas = true;
    private Text _hiScoreText;

    private bool _gameOver = true;

    // Start is called before the first frame update
    public AudioSource _musik;
    void Start()
    {
        if(!PlayerPrefs.HasKey("HighScore")){
            PlayerPrefs.SetFloat("HighScore", _hiScore);
            PlayerPrefs.Save();
        }
        else{
            _hiScore = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        _musik.volume = PlayerPrefs.GetFloat("MusVol");
        if(_gas)
        {
            _score += _trackScript.kecepatan * Time.deltaTime;
            _scoreText.text = "" + (int)_score;
            if( _score > _hiScore){
                _hiScore = _score;
                PlayerPrefs.SetFloat("HighScore", _hiScore);
                PlayerPrefs.Save();
            }
            _coinText.text = "" + _coinCount;
        }
        if( !_gas && _gameOver )
        {
            // Menjumlahkan total coin
            float _totalCoin = PlayerPrefs.GetFloat("Coin") + _coinCount;
            PlayerPrefs.SetFloat("Coin", _totalCoin);
            PlayerPrefs.Save();
            
            // Memumculkan Page Game Over
            SceneManager.LoadScene(2);
        }
    }
}
