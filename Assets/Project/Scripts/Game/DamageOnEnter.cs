using System;
using UnityEngine;

public class DamageOnEnter : MonoBehaviour
{
    [SerializeField] private int _damage = 10;

    public event Action Damaged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Damageable>(out var damageable))
        {
            damageable.Damage(_damage);
            Damaged?.Invoke();
        }
    }
}