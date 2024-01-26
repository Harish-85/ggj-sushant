using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    private bool notestatus;
    public GameObject note;
   public void ToggleNote()
    {
       notestatus=!notestatus;
        note.SetActive(notestatus);
       

    }
    public bool GetNoteStatus()
    {
        return notestatus;
    }
}
