using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject pickupText;
    public GameObject FlashOn;
    void Start()
    {
        FlashOn.SetActive(false);
        pickupText.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickupText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                FlashOn.SetActive(true);
                pickupText.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        pickupText.SetActive(false);
    }
}
