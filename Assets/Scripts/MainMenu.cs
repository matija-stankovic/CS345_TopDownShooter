using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string MainScene = "SampleScene";

    //Start
    public void PlayGame()
    {
        SceneManager.LoadScene(MainScene);
    }   

    //Exit
    public void QuitGame()
    {
        Application.Quit();
    }

}
