using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu1 : MonoBehaviour
{
    [SerializeField] private GameObject optionPanel, mainMenuPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("GAME");
    }

    //public void ShowOptions()
    //{
    //    mainMenuPanel.SetActive(false);
    //    optionPanel.SetActive(true);
    //}

   // public void ShowMainMenu()
    //{
   //     mainMenuPanel.SetActive(true);
    //    optionPanel.SetActive(false);
   // }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

}
