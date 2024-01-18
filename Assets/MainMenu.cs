using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource _musik;

    void Start(){
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
}
