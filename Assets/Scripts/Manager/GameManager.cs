using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    
    public static bool isAutoRun;
    [SerializeField] Animator transitionAnim;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                if (_instance == null)
                {
                    GameObject managerObject = new GameObject("GameManager");
                    _instance = managerObject.AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }

    // Other GameManager functionality and game-related code goes here

    private void Awake()
    {    
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AutoRunOption()
    {
        isAutoRun = true;
    }

    public void NormalRunOption()
    {
      isAutoRun = false;
    }

    public void RestartGame()
    {
       
        StartCoroutine(LoadScene());
  
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("End");

        yield return new WaitForSeconds(1);
        //AudioManager._instance.StopMusic();
        
        if (isAutoRun == true)
        {
            SceneManager.LoadScene("Level1");
        }
        else
        {
            //Debug.Log("Auto Run" + GameManager.isAutoRun);
            SceneManager.LoadScene("Procedural");
        }
        transitionAnim.SetTrigger("Start");
        //AudioManager._instance.PlayMusic("LevelMusic");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        
        StartCoroutine(GameOverIenumerator());
    }

    IEnumerator GameOverIenumerator()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("GameOver");
        transitionAnim.SetTrigger("Start");
        
    }

    public void NextLevel()
    {
        StartCoroutine (NextLevelIenumerator());
    }


    IEnumerator NextLevelIenumerator()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        transitionAnim.SetTrigger("Start");
    }

    public void LevelSelection(string level) 
    {
    SceneManager.LoadScene(level);
    }
   
}
