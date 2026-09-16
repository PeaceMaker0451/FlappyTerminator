using UnityEngine;
using Zenject;
using UnityEngine.InputSystem;
using System;

[RequireComponent(typeof(Jumper))]
public class Player : MonoBehaviour
{
    private IInputProvider _input;
    private Jumper _jumper;

    [Inject]
    private void Inject(IInputProvider input)
    {
        Debug.Log("PlayerInject");
        _input = input;
    }

    private void Awake()
    {
        _jumper = GetComponent<Jumper>();
    }

    private void Start()
    {
        _input.GameplayJump.performed += OnPlayerJump;
        _input.GameplayShoot.performed += OnPlayerShoot;
    }

    private void OnPlayerShoot(InputAction.CallbackContext context)
    {
        Debug.Log("PlayerShoot");
    }

    private void OnPlayerJump(InputAction.CallbackContext callback)
    {
        Debug.Log("PlayerJump");
        _jumper.Jump();
    }
}
