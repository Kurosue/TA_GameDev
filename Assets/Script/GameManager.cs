using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text _scoreText;
    public Text _coinText;

    private float _score = 0f;
    private float _hiScore = 0f;

    public tracka _trackScript;
    public float _coinCount = 0f;

    public bool _gas = true;
    public GameObject _gameOverPage;
    private Text _hiScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("HighScore") == null){
            PlayerPrefs.SetFloat("HighScore", _hiScore);
            PlayerPrefs.Save();
        }
        if(PlayerPrefs.GetFloat("Coin") == null){
            PlayerPrefs.SetFloat("Coin", _coinCount);
            PlayerPrefs.Save();
        }
        _scoreText.text = "score: " + _score;
    }

    // Update is called once per frame
    void Update()
    {
        if(_gas)
        {
            _score += _trackScript.kecepatan * Time.deltaTime;
            _scoreText.text = "score: " + (int)_score;
            if( _score > _hiScore){
                _hiScore = _score;
                PlayerPrefs.SetFloat("HighScore", _hiScore);
                PlayerPrefs.Save();
            }
            _coinText.text = "" + _coinCount;
        }
        else{
            // Menjumlahkan total coin
            float _totalCoin = PlayerPrefs.GetFloat("Coin") + _coinCount;
            PlayerPrefs.SetFloat("Coin", _coinCount);
            PlayerPrefs.Save();
            
            // Memumculkan Page Game Over
            Instantiate(_gameOverPage, new Vector3(0f, -0.75f, 0f), Quaternion.identity);
            _hiScoreText = _gameOverPage.GetComponentInChildren<Text>();
            _hiScoreText.text = "HighScore : " + (int)_hiScore;
        }

    }
}
