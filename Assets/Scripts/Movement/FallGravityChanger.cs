using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(RigidbodyGravityScale))]
public class FallGravityChanger : MonoBehaviour
{
    [SerializeField] private float _fallGravity = 15f;
    [SerializeField] private float _jumpGravity = 35f;

    private Rigidbody _rigidbody;
    private RigidbodyGravityScale _gravityScale;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _gravityScale = GetComponent<RigidbodyGravityScale>();
    }

    private void FixedUpdate()
    {
        var velocity = _rigidbody.velocity;

        if (velocity.y > 0)
            _gravityScale.SetGravityScale(_jumpGravity);
        else
            _gravityScale.SetGravityScale(_fallGravity);
    }
}
