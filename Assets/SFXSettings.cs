using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSettings : MonoBehaviour
{
    public Slider _slider;
    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat("SFXVol");
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = PlayerPrefs.GetFloat("SFXVol");
        PlayerPrefs.SetFloat("SFXVol", _slider.value);
        PlayerPrefs.Save;
    }
}
