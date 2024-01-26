using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoteScript : MonoBehaviour
{
    private NoteScript activeNote;
    private GameObject interactMessage;
    void Start()
    {
        interactMessage = GameObject.Find("interactMessage");
        interactMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (activeNote)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                activeNote.ToggleNote();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Note")
        {
            other.gameObject.TryGetComponent(out activeNote);
            interactMessage.SetActive(true);   
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Note")
        {
            if(activeNote.GetNoteStatus())
            {
                activeNote.ToggleNote();
                activeNote = null;
                interactMessage.SetActive(false);
            }
        }
    }
}
