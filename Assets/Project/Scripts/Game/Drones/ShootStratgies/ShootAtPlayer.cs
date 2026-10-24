using UnityEngine;

public class ShootAtPlayer : ShootStrategy
{
    [SerializeField] private float _shootDelay = 1f;
    [SerializeField] private float _aimSpeed = 1f;

    private float _shootTime = float.MinValue;

    public override void Tick(Transform player, IDroneWeapon shooter)
    {
        Vector3 difference = player.position - shooter.transform.position;
        float targetAngle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        shooter.RotateAt(Mathf.LerpAngle(shooter.CurrentAngle, targetAngle, _aimSpeed * Time.deltaTime));

        if (Time.time > _shootTime + _shootDelay)
        {
            _shootTime = Time.time;
            shooter.Shoot();
        }
    }
}
