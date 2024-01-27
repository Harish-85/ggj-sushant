using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScriptPick : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    public GameObject hud;
    public GameObject inv;
    public GameObject pickUpText;
    public AudioSource pickUpSound;
    public bool inReach;

    void Start()
    {
        noteUI.SetActive(false);
        hud.SetActive(true);
        inv.SetActive(true);
        pickUpText.SetActive(false);
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inReach)
        {
            ShowNote();
        }

        
        if (Input.GetKeyDown(KeyCode.Tab) && noteUI.activeSelf)
        {
            HideNote();
        }
    }

    void ShowNote()
    {
        noteUI.SetActive(true);
        pickUpSound.Play();
        hud.SetActive(false);
        inv.SetActive(false);
        player.GetComponent<ThirdPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void HideNote()
    {
        noteUI.SetActive(false);
        hud.SetActive(true);
        inv.SetActive(true);
        player.GetComponent<ThirdPersonController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}




