using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneControl : MonoBehaviour
{
    private bool microphoneEnabled = true;
    private AudioSource audioSource;

    private void Start()
    {
        // Create an AudioSource component if not already present
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Start with the microphone enabled
        EnableMicrophone();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for key input to toggle microphone state
        if (Input.GetKeyDown(KeyCode.M))
        {
            microphoneEnabled = !microphoneEnabled;

            if (microphoneEnabled)
            {
                // Enable microphone
                EnableMicrophone();
                Debug.Log("Microphone enabled");
            }
            else
            {
                // Disable microphone
                DisableMicrophone();
                Debug.Log("Microphone disabled");
            }
        }
    }

    private void EnableMicrophone()
    {
        // You may need to adjust the device name and other parameters based on your setup
        string microphoneDevice = Microphone.devices.Length > 0 ? Microphone.devices[0] : null;
        if (microphoneDevice != null)
        {
            // Start recording from the specified microphone device
            //audioSource.clip = Microphone.Start(microphoneDevice, true, 10, 44100);
           // audioSource.loop = true;

            // Wait for the microphone to start
            while (!(Microphone.GetPosition(microphoneDevice) > 0))
            {
            }

            // Play the audio source
            //audioSource.Play();
        }
        else
        {
            Debug.LogError("No microphone device found.");
        }
    }

    private void DisableMicrophone()
    {
        // Stop the microphone
        Microphone.End(null);

        // Stop playing the audio source
        audioSource.Stop();
    }
}
