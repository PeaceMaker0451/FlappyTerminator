using UnityEngine;

[RequireComponent(typeof(Health))]
public class RestoreHealthOnReset : MonoBehaviour, IResetable
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void ResetComponent()
    {
        _health.Set(_health.MaxPoints);
    }
}
