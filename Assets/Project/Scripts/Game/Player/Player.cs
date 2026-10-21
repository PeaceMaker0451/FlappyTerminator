using UnityEngine;
using Zenject;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Jumper), typeof(Shooter))]
public class Player : MonoBehaviour, IDisableOnDeath
{
    private IInputProvider _input;
    private Jumper _jumper;
    private Shooter _shooter;

    public float ShootReadyTime => _shooter.TimeBeforeShoot;
    public float ShootDelay => _shooter.Delay;

    public float JumpReadyTime => _jumper.TimeBeforeJump;
    public float JumpDelay => _jumper.Delay;

    [Inject]
    private void Inject(IInputProvider input)
    {
        Debug.Log("PlayerInject");
        _input = input;
    }

    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
        _jumper = GetComponent<Jumper>();
    }

    private void Start()
    {
        _input.GameplayJump.performed += OnPlayerJump;
        _input.GameplayShoot.performed += OnPlayerShoot;
    }

    private void OnPlayerShoot(InputAction.CallbackContext context)
    {
        if(enabled == false) return;
        
        Debug.Log("PlayerShoot");
        _shooter.Shoot();
    }

    private void OnPlayerJump(InputAction.CallbackContext callback)
    {
        if (enabled == false) return;

        Debug.Log("PlayerJump");
        _jumper.Jump();
    }
}
