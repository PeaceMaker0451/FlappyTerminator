using UnityEngine;

public class ShootStraight : ShootStrategy
{
    [SerializeField] private float _shootDelay = 1f;

    private float _shootTime = float.MinValue;

    public override void Tick(Transform player, IDroneWeapon shooter)
    {
        if (Time.time > _shootTime + _shootDelay)
        {
            _shootTime = Time.time;

            shooter.Shoot();
        }
    }
}
