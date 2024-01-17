using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnetTimer : MonoBehaviour
{
    Image _magnetTimer;
    float _maxTime = 15f;
    public ColliderOnlyForCoin _timer;
    float _timeLeft;
    void Start()
    {
        _magnetTimer = GetComponent<Image>();
        _timeLeft = _maxTime - _timer._timer;
    }

    // Update is called once per frame
    void Update()
    {
        if(_timeLeft > 0f)
        {
            _timeLeft = _maxTime - _timer._timer;
            _magnetTimer.fillAmount = _timeLeft / _maxTime;
        }
        
    }
}
