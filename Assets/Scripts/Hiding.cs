using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hiding : MonoBehaviour
{
    [SerializeField] GameObject hideText, stopHideText;
    [SerializeField] GameObject normalPlayer, hidingPlayer;
    [SerializeField] EnemyAI monsterScript;
    [SerializeField] Transform monsterTransform;
    public bool interactable, hiding;
    [SerializeField] float loseDistance;
   // [SerializeField] AudioSource hideSound, stopHideSound;
   // [SerializeField] roomDetector detector;
    [SerializeField] SwitchPlayer switchPlayerCam;
    
  
    void Start()
    {
        interactable = false;
        hiding = false;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
           
                hideText.SetActive(true);
                interactable = true;
       
           
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            hideText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {  
               
               
                hideText.SetActive(false);
                switchPlayerCam.SwitchPlayerCamWhenHiding();
                //hideSound.Play();
                hidingPlayer.SetActive(true);
                float distance = Vector3.Distance(monsterTransform.position, normalPlayer.transform.position);
                if (distance > loseDistance)
                {
                    if (monsterScript.chasing == true)
                    {
                        monsterScript.stopChase();
                    }
                }
                stopHideText.SetActive(true);
                hiding = true;
                normalPlayer.SetActive(false);
                interactable = false;
            }
        }
        if (hiding == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {    
               
                stopHideText.SetActive(false);
                switchPlayerCam.SwitchPlayerCamToOriginal();
               // stopHideSound.Play();
                normalPlayer.SetActive(true);
                hidingPlayer.SetActive(false);
                hiding = false;
            }
        }
    }
}
