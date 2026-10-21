using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DisableColliderOnDeath : MonoBehaviour, IActOnDeath, IResetable
{
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    public void OnDied()
    {
        _collider.enabled = false;
    }

    public void ResetComponent()
    {
        _collider.enabled = true;
    }
}
