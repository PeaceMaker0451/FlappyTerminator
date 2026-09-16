using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _jumpCooldownSeconds = 0.5f;
    
    private Rigidbody _rigidbody;
    private float _lastJumpTime = float.MinValue;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if(CanJump())
        {
            _rigidbody.velocity = Vector3.up * _jumpForce;
            WriteJumpTime();
        }
    }
    
    private bool CanJump()
    {
        return _lastJumpTime + _jumpCooldownSeconds < Time.time;
    }

    private void WriteJumpTime()
    {
        _lastJumpTime = Time.time;
    }
}
