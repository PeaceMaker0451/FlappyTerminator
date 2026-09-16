using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlaneRotator : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationAxis = Vector3.right;
    [SerializeField] private Vector3 _offset;

    [SerializeField] private float _rotationSpeed = 0.2f;

    [SerializeField] protected float _maxDownAngle;
    [SerializeField] protected float _maxUpAngle;

    private Rigidbody _rigidody;
    private Transform _transform;

    private void Awake()
    {
        _rigidody = GetComponent<Rigidbody>();
        _rigidody.constraints = RigidbodyConstraints.FreezeRotation;
        _transform = transform;
    }

    private void Update()
    {
        var yVelocity = _rigidody.velocity.y;

        Quaternion targetRotation;

        if (yVelocity > 0)
        {
            targetRotation = Quaternion.Euler(_rotationAxis * _maxUpAngle + _offset);
        }
        else
        {
            targetRotation = Quaternion.Euler(_rotationAxis * -1 * _maxDownAngle + _offset);
        }

        _transform.rotation = Quaternion.Lerp(_transform.rotation, targetRotation, _rotationSpeed);
    }
}
