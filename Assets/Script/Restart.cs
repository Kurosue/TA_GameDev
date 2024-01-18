using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    void Start()
    {
    // Assuming the Button is a direct child of the GameObject this script is attached to
    Button restartButton = GetComponentInChildren<Button>();

    if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
    }


    public void RestartGame()
    {
        Debug.Log("yhsjdfhijashifdhs");
        // Load the current scene to reset other objects if needed
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}