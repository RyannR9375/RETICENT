using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;

    public GameOverScreen GameOverScreen;
    public GameObject Player;

    public bool isPaused = false;

    private int CollectedItems, victoryCondition = 3;
    private int HealTimes = 1;
    private int HealTimesValue = 1;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }

    private static GameManager instance;

    public static GameManager MyInstance
    {
        get
        {
            if (instance == null)
                instance = new GameManager();

            return instance;
        }
    }

    public void AddItems(int _items)
    {
        CollectedItems += _items;
        UIManager.MyInstance.UpdateItemUI(CollectedItems, victoryCondition);
    }

    public void HealTimesUI(int _times)
    {
        HealTimes -= _times;
        UIManager.MyInstance.UpdateHealTimesUI(HealTimes);
    }

    public void SwitchPause()
    {
        if (GameOverYesNo == false)
        {
            pauseUI.SetActive(!pauseUI.activeSelf);
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
            isPaused = isPaused = true ? false : true;
        }
    }

    public void SwitchPauseScream()
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
        UIManager.MyInstance.UpdateItemUI(CollectedItems, victoryCondition);
        UIManager.MyInstance.UpdateHealTimesUI(HealTimes);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchPause();
        }

        if (GameOverYesNo == true)
        {
            SwitchPauseScream();
        }

        if (CollectedItems >= victoryCondition)
        {
            SceneManager.LoadScene("BEAT GAME");
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
    public void MenuFromDeath()
    {
        if (SceneManager.GetActiveScene().name == "GAME OVER")
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }

    public void MenuFromVictory()
    {
        if (SceneManager.GetActiveScene().name == "BEAT GAME")
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }


    public void Retry()
    {
        SceneManager.LoadScene("GAME");
    }
    public void GameOver()
    {
        GameOverScreen.Setup();
        GameOverYesNo = true;
    }

    public void Finish()
    {
        if(CollectedItems >= victoryCondition)
        {
            SceneManager.LoadScene("BEAT GAME");
        }
    }
}
