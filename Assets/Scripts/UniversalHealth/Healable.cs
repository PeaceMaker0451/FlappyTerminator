using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Healable : MonoBehaviour
{
    private Health _health;

    public event Action Healed;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public int Heal(int points)
    {
        _health.Increase(points, out int actualChange);
        
        if(actualChange != 0)
            Healed?.Invoke();

        return actualChange;
    }
}