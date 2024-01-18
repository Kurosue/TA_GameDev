using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioSource _musik;
    public Text _coinTXT;

    void Start(){

        if(!PlayerPrefs.HasKey("Coin")){
            PlayerPrefs.SetFloat("Coin", 0f);
            PlayerPrefs.Save();
        }
        if(!PlayerPrefs.HasKey("MagnetTimer")){
            PlayerPrefs.SetFloat("MagnetTimer", 15f);
            PlayerPrefs.Save();
        }
        if(!PlayerPrefs.HasKey("MusVol")){
            PlayerPrefs.SetFloat("MusVol", 1);
            PlayerPrefs.Save();
        }
        if(!PlayerPrefs.HasKey("SFXVol")){
            PlayerPrefs.SetFloat("SFXVol", 1);
            PlayerPrefs.Save();
        }
    }
    void Update(){
        _coinTXT.text = "" + (int)PlayerPrefs.GetFloat("Coin");
        _musik.volume = PlayerPrefs.GetFloat("MusVol");
    }
    public void PlayGame ()
    {
        Debug.Log("Acumalaka");
        SceneManager.LoadScene(1);
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();

    }
    public void IncreaseButton(){
        float _curr = PlayerPrefs.GetFloat("MagnetTimer");
        if(PlayerPrefs.GetFloat("Coin") >= 10000f){
            float _minusCoin = PlayerPrefs.GetFloat("Coin") - 10000f;
            PlayerPrefs.SetFloat("Coin", _minusCoin);
            PlayerPrefs.Save();
            _curr += 5f;
            PlayerPrefs.SetFloat("MagnetTimer", _curr);
            PlayerPrefs.Save();

        }
    }
}
