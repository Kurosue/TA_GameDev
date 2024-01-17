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
    public GameObject _gameOverPage;
    private Text _hiScoreText;

    private bool _gameOver = true;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("HighScore")){
            PlayerPrefs.SetFloat("HighScore", _hiScore);
            PlayerPrefs.Save();
        }
        else{
            _hiScore = PlayerPrefs.GetFloat("HighScore");
        }
        if(!PlayerPrefs.HasKey("Coin")){
            PlayerPrefs.SetFloat("Coin", _coinCount);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
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
            GameObject gameOverInstance = Instantiate(_gameOverPage, new Vector3(0f, -0.75f, 0f), Quaternion.identity);
            _hiScoreText = gameOverInstance.GetComponentInChildren<Text>();
            _hiScoreText.text = "HighScore : " + (int)PlayerPrefs.GetFloat("HighScore");
            _gameOver = false;
        }
    }


}
