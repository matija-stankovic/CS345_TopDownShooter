using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPauseMenu : MonoBehaviour
{

    public static bool paused = false;

    public GameObject pauseMenuUI;

    public GameObject gameOverUI;

    public GameObject player;

    public string MainScene = "Level1";


    // Update is called once per frame
    void Update()
    {

        if (player == null || Input.GetKeyDown(KeyCode.P))
        {
            GameOver();
        }

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void MainMenu()
    {
        pauseMenuUI.SetActive(false);
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        SceneManager.LoadScene("StartMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(MainScene);
        Resume();
        pauseMenuUI.SetActive(false);
        gameOverUI.SetActive(false);

    }

    public void ResumeOnClick()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void GameOver()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Time.timeScale = 0f;
        paused = true;
        gameOverUI.SetActive(true);
    }
}
