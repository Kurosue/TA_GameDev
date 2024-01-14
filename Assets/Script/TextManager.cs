using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text _scoreText;
    public Text _coinText;

    private float _score = 0f;
    private float _hiScore = 0f;

    public tracka _trackScript;
    public float _coinCount = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "score: " + _score;
    }

    // Update is called once per frame
    void Update()
    {
        _score += _trackScript.kecepatan * Time.deltaTime;
        _scoreText.text = "score: " + (int)_score;
        if( _score > _hiScore){
            _hiScore = _score;
            PlayerPrefs.SetFloat("HighScore", _hiScore);
        }

        _coinText.text = "" + _coinCount;
    }
}
