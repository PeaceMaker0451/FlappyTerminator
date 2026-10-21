using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlaneRotator : MonoBehaviour, IDisableOnDeath
{
    [SerializeField] private Vector3 _rotationAxis = Vector3.right;
    [SerializeField] private Vector3 _offset;

    [SerializeField] private float _rotationSpeed = 0.2f;

    [SerializeField] private float _maxDownAngle;
    [SerializeField] private float _maxUpAngle;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody == null) return;

        float yVelocity = _rigidbody.velocity.y;
        Quaternion targetRotation;

        if (yVelocity > 0)
        {
            targetRotation = Quaternion.Euler(_rotationAxis * _maxUpAngle + _offset);
        }
        else
        {
            targetRotation = Quaternion.Euler(_rotationAxis * -1 * _maxDownAngle + _offset);
        }

        Quaternion newRotation = Quaternion.Lerp(_rigidbody.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime);
        _rigidbody.MoveRotation(newRotation);
    }
}
