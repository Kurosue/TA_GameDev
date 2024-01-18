using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnetTimer : MonoBehaviour
{
    Image _magnetTimer;
    float _maxTime = 15f;
    GameObject _timerM;
    bool _fill = true;
    public bool _spawn;
    float _timeLeft;
    private float _timefill = 0f;
    float _timer;
    void Start()
    {
        _timerM = GameObject.FindGameObjectWithTag("CoinColl");
        _magnetTimer = GetComponent<Image>();
        _magnetTimer.fillAmount = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        _maxTime = PlayerPrefs.GetFloat("MagnetTimer");
        _timer = _timerM.GetComponent<ColliderOnlyForCoin>()._timer;
        _timeLeft = _maxTime - _timer;
        if(_fill)
        {
            _timefill += Time.deltaTime;
            _magnetTimer.fillAmount += (_timefill / 13);
            if((_timefill / 13) >= (_timeLeft / _maxTime) || _magnetTimer.fillAmount >= 1)
            {
                _fill = false;
                _timefill = 0;
            } 
        }
        else if(_timeLeft > 0.5f)
        {
            _magnetTimer.fillAmount = _timeLeft / _maxTime;
        }else{
            _spawn = false;
        }
        
    }
}
