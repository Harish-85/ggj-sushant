using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class PauseMenuScripts : MonoBehaviour
{
   
    public bool IsPause;

    public GameObject panel;
    void Start()
    {
        panel.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        IsPause = true;


    }
    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        IsPause = false;

    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }
}


