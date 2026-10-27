using UnityEngine;

public class ShootStraight : WeaponStrategy
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
