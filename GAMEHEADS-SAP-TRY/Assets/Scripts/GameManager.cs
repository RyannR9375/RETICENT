using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    public GameObject Player;

    public bool isPaused = false;

    public void SwitchPause()
    {
        if (GameOverYesNo == false)
        {
            pauseUI.SetActive(!pauseUI.activeSelf);
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
            isPaused = isPaused = true ? false : true;
        }
    }

    public bool GameOverYesNo;

    private Sprite playersprite;
    // Start is called before the first frame update
    void Start()
    {

        Player.GetComponent<SpriteRenderer>().sprite = playersprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchPause();
        }
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void Menu()
    {
        if (SceneManager.GetActiveScene().name == "GAME")
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("GAME");
    }
}
