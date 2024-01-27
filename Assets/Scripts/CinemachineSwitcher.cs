using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField] InputAction action;

    Animator animator;
    [SerializeField] GameObject flashLight;
    bool fpp = true;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }
    void Start()
    {
        action.performed += _ => SwitchState();
    }

    void SwitchState()
    {
        if (fpp)
        {   
            flashLight.SetActive(false);
            animator.Play("TPP");
        }
        else
        {
            flashLight.SetActive(true);
            animator.Play("FPP");
        }
        fpp = !fpp;
    }
}
