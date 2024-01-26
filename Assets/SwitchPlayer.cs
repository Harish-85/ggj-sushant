using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera; // Drag your virtual camera here in the Unity Editor

    [SerializeField] Transform hidingPlayer; // Drag your new follow target here in the Unity Editor
    [SerializeField] Transform originalPlayer;
   
    public void SwitchPlayerCamWhenHiding()
    {
        virtualCamera.Follow = hidingPlayer;
    }

    public void SwitchPlayerCamToOriginal()
    {
        virtualCamera.Follow = originalPlayer;
    }
}
