using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBoxScript : MonoBehaviour
{
    public Animator boxOB;
    public GameObject keyOBNeeded;
    public GameObject openText;
    public GameObject keyMissingText;
    public AudioSource openSound;

    public bool inReach;
    public bool isOpen;



    void Start()
    {
        inReach = false;
        openText.SetActive(false);
        keyMissingText.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            keyMissingText.SetActive(false);
        }
    }


    void Update()
    {
        if (keyOBNeeded.activeInHierarchy == true  && Input.GetKeyDown(KeyCode.E))
        {
            if (inReach)
            {
                keyOBNeeded.SetActive(false);
                openSound.Play();
                boxOB.SetBool("open", true);
                openText.SetActive(false);
                isOpen = true;
                keyMissingText.SetActive(false);
            }
        }

        else if (keyOBNeeded.activeInHierarchy == false && inReach && Input.GetKeyDown(KeyCode.E))
        {
            openText.SetActive(false);
            keyMissingText.SetActive(true);
        }

        if (isOpen)
        {
            boxOB.GetComponent<BoxCollider>().enabled = false;
            boxOB.GetComponent<OpenBoxScript>().enabled = false;
        }
    }
}
