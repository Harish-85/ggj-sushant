using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

   
    public void Quit()
    {
        Application.Quit();
    }

}
