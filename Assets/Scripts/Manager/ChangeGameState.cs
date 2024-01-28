using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGameState : MonoBehaviour
{
   public void callGameManagerForRestart()
    {
        GameManager.Instance.RestartGame();
    }

    public void callGameManagerForQuit()
    {
        GameManager.Instance.QuitGame();
    }

    public void callAutoRun()
    {
        GameManager.Instance.AutoRunOption();
    }

    public void callNormalRun()
    {
        GameManager.Instance.NormalRunOption();
    }
    public void MainMenu()
    {
        GameManager.isAutoRun = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void CallLevelSelection(string level)
    {
        GameManager.Instance.LevelSelection(level);
    }
}
