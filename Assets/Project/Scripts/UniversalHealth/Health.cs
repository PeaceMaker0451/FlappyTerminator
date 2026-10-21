using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public event Action Changed;

    public int Points { get; private set; }
    public int MaxPoints => _maxHealth;

    private void Awake()
    {
        Points = _maxHealth;    
    }

    public void Increase(int points)
    {
        Points += points;
        ValidateHealth();
    }

    public void Increase(int points, out int actualChange)
    {
        int health = Points;
        Increase(points);
        actualChange = Points - health;
    }

    public void Decrease(int points)
    {
        Points -= points;
        ValidateHealth();
    }

    public void Decrease(int points, out int actualChange)
    {
        int health = Points;
        Decrease(points);
        actualChange = health - Points;
    }

    public void Set(int points)
    {
        Points = points;
        ValidateHealth();
    }

    private void ValidateHealth()
    {
        Points = Mathf.Clamp(Points, 0, _maxHealth);
        Changed?.Invoke();
    }
}