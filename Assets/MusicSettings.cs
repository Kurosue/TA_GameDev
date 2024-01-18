using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSettings : MonoBehaviour
{
    public Slider _slider;
    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat("MusVol");
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = PlayerPrefs.GetFloat("MusVol");
        PlayerPrefs.SetFloat("MusVol", _slider.value);
        PlayerPrefs.Save;
    }
}
