using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DisablePhysicsOnDeath : MonoBehaviour, IActOnDeath
{
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void OnDied()
    {
        _rigidBody.isKinematic = true;
    }
}