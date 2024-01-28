using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class AudioManager : MonoBehaviour
{


    public static AudioManager _instance;

    [SerializeField] VideoPlayer audio;
    public Sound[]musicSounds;
    [SerializeField] AudioSource musicSource;

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

    /*private void Start()
    {
        PlayMusic("Theme");
    }*/
   /* public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds , x=> x.audioName==name);

        if(s != null)
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
*/
    /*public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }*/

    public void ToggleMusic()
    {
        //musicSource.mute = !musicSource.mute;
    }

    public void MusicVolume(float volume)
    {
        audio.GetTargetAudioSource(0).volume = volume;
        musicSource.volume = volume;
    }
}
