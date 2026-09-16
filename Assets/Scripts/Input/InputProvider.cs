using UnityEngine;
using UnityEngine.InputSystem;

public class InputProvider : MonoBehaviour, IInputProvider
{
    private CommonActions _actions;
    
    public InputAction GameplayShoot => _actions.Gameplay.Shoot;
    public InputAction GameplayJump => _actions.Gameplay.Jump;

    private void Awake()
    {
        _actions = new();
        EnableGameplayScheme();
    }

    public void EnableGameplayScheme()
    {
        _actions.Gameplay.Enable();
    }
}
