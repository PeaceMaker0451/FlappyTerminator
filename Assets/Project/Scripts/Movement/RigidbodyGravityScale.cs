using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyGravityScale : MonoBehaviour
{
    [SerializeField] private float _gravityScale = 1;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
    }

    private void FixedUpdate()
    {
        Vector3 gravity = Physics.gravity * _gravityScale;
        _rigidbody.AddForce(gravity, ForceMode.Acceleration);
    }

    public void SetGravityScale(float gravityScale)
    {
        _gravityScale = gravityScale;
    }
}
