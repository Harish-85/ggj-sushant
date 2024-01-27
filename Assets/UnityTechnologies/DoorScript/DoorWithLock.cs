using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsWithLock : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public GameObject KeyINV;

    public AudioSource doorSound;
    public AudioSource lockedSound;


    public bool inReach;
    public bool unlocked;
    public bool locked;
    public bool hasKey;





    void Start()
    {
        inReach = false;
        hasKey = false;
        unlocked = false;
        locked = true;
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
        }
    }





    void Update()
    {
        if (KeyINV.activeInHierarchy)
        {
            locked = false;
            hasKey = true;
        }

        else
        {
            hasKey = false;
        }

        if (hasKey  && Input.GetKeyDown(KeyCode.E))
            if( inReach)
        {
            unlocked = true;
            DoorOpens();
        }

        else
        {
            DoorCloses();
        }

        if (locked && inReach && Input.GetKeyDown(KeyCode.E))
        {
            lockedSound.Play();

        }




    }
    void DoorOpens()
    {
        if (unlocked)
        {
            door.SetBool("open", true);
            door.SetBool("close", false);
            doorSound.Play();
        }

    }

    void DoorCloses()
    {
        if (unlocked)
        {
            door.SetBool("open", false);
            door.SetBool("close", true);
        }

    }


}
