using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Damageable : MonoBehaviour
{
    private Health _health;

    public event Action Damaged;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public int Damage(int damage)
    {
        _health.Decrease(damage, out int change);

        if(change != 0)
            Damaged?.Invoke();

        return change;
    }

    public void Kill()
    {
        _health.Set(0);
        Damaged?.Invoke();
    }
}