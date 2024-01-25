using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField] InputAction action;

    Animator animator;

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
            animator.Play("TPP");
        }
        else
        {
            animator.Play("FPP");
        }
        fpp = !fpp;
    }
}
