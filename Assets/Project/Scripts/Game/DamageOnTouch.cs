using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Damageable>(out var damageable))
        {
            damageable.Damage(_damage);
            Debug.Log($"{gameObject.name} damage - {collision.gameObject.name}");
        }
    }
}