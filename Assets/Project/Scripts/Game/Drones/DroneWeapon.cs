using UnityEngine;

public class DroneWeapon : MonoBehaviour, IDroneWeapon
{
    [SerializeField] private Transform _shooterPoint;
    [SerializeField] [Range(-180, 180)] private float _minAngle;
    [SerializeField] [Range(-180, 180)] private float _maxAngle;

    [SerializeField] private bool _isLeft = true;
    
    private IProjectileSpawner _shooter;

    public float CurrentAngle => HandleRotationDirection(transform.eulerAngles.z);

    public void Initialize(IProjectileSpawner shooter)
    {
        _shooter = shooter;
    }

    public void RotateAt(float angle)
    {
        angle = HandleRotationDirection(angle);
        angle = Mathf.DeltaAngle(0f, angle);

        angle = Mathf.Clamp(angle, _minAngle, _maxAngle);

        transform.rotation = Quaternion.Euler(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            angle
        );
    }

    public void Shoot()
    {
        _shooter.Shoot(_shooterPoint.position, _shooterPoint.right);
    }

    private void OnDrawGizmos()
    {
        float rayScale = 5;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + GunForwardDirection() * rayScale);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * rayScale);

        Gizmos.color = Color.green;

        Quaternion minAngleRotation = Quaternion.Euler(new(0, 0, _minAngle - transform.eulerAngles.z));
        Vector3 minAngleRotatedVector = minAngleRotation * GunForwardDirection();
        Gizmos.DrawLine(transform.position, transform.position + minAngleRotatedVector * rayScale);

        Quaternion maxAngleRotation = Quaternion.Euler(new(0, 0, _maxAngle - transform.eulerAngles.z));
        Vector3 maxAngleRotatedVector = maxAngleRotation * GunForwardDirection();
        Gizmos.DrawLine(transform.position, transform.position + maxAngleRotatedVector * rayScale);
    }

    private float HandleRotationDirection(float angle)
    {
        if(_isLeft)
            return (angle + 180f) % 360f;
        else
            return angle;
    }

    private Vector3 GunForwardDirection()
    {
        if (_isLeft)
            return transform.right * -1;
        else
            return transform.right;
    }
}
