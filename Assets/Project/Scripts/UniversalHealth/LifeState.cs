using System;
using UnityEngine;

[RequireComponent(typeof(Health))] 
public class LifeState: MonoBehaviour
{
    private Health _health;

    public event Action Died;

    public bool IsDead;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.Changed += OnHealthChanged;
    }

    private void OnDestroy()
    {
        _health.Changed -= OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        bool wasDead = IsDead;
        IsDead = _health.Points <= 0;

        if (wasDead == false && IsDead)
            Died?.Invoke();
    }
}
