using UnityEngine;

public class FanShoot : ShootStrategy
{
    [SerializeField] private float _shootDelay = 0.2f;
    [SerializeField] private float _aimSpeed = 1f;
    [SerializeField] private float _fanAngle = 60f;

    private float _shootTime = float.MinValue;
    private float _fanProgress = 0;
    private int _direction = 1;

    public float TargetAngle { get; private set; }

    public override void Tick(Transform player, IDroneWeapon shooter)
    {
        Vector3 difference = player.position - shooter.transform.position;
        float angleToPlayer = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        _fanProgress += _direction * _aimSpeed * Time.deltaTime;

        if (_fanProgress >= 1f)
        {
            _fanProgress = 1;
            _direction = -1;
        }
        else if (_fanProgress <= -1f)
        {
            _fanProgress = -1f;
            _direction = 1;
        }

        TargetAngle = angleToPlayer + _fanAngle / 2f * _fanProgress;
        shooter.RotateAt(TargetAngle);

        if (Time.time >= _shootTime + _shootDelay)
        {
            _shootTime = Time.time;
            shooter.Shoot();
        }
    }
}
