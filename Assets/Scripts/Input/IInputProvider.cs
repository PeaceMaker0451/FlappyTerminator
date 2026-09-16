using UnityEngine.InputSystem;

public interface IInputProvider
{
    public InputAction GameplayShoot { get; }
    public InputAction GameplayJump { get; }

    public void EnableGameplayScheme();
}
