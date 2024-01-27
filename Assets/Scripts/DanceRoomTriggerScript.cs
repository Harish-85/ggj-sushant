using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceRoomTriggerScript : MonoBehaviour
{
    [SerializeField] AudioSource DanceRoomAudio;
    [SerializeField] AudioClip songClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DanceRoomAudio.Stop();

            DanceRoomAudio.volume = 0.56f;
            DanceRoomAudio.rolloffMode = AudioRolloffMode.Linear;
            DanceRoomAudio.clip = songClip;
            DanceRoomAudio.Play();
        }
    }
}
