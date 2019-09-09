using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void ViewHighScores()
    {
        PlayerPrefs.SetInt("playerScore", -1);
        SceneManager.LoadScene("HighScore");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
