using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public GameObject playPanel;
    public Toggle confirmToggle;

    void Update()
    {
      ConfirmToggle();
    }

    public void OpenGame()
    {
         SceneManager.LoadScene("SplashScene");
    }
    public void QuitButton()
    {
         // save any game data here
    #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif

    }

    public void PlusButton()
    {
       playPanel.SetActive(true);
    }

     public void ConfirmToggle()
    {

        if(confirmToggle.isOn){
            playPanel.SetActive(true);
        }
        else{
            playPanel.SetActive(false);
        }
       
    }

}
