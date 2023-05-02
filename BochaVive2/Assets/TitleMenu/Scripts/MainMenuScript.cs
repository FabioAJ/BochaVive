using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("ForestStage");
    }

    /*
    public void OptionsMenu()
    {
        underDev
    }
    */

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
