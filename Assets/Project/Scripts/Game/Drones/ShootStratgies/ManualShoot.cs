using UnityEngine;

public class ManualShoot : ShootStrategy
{
    [SerializeField] private float _shootDelay = 1f;

    private IDroneWeapon _shooter;
    private float _shootTime;

    public override void Tick(Transform player, IDroneWeapon shooter)
    {
        _shooter = shooter;
    }

    public void Shoot()
    {
        if (Time.time > _shootTime + _shootDelay)
        {
            _shootTime = Time.time;
            _shooter.Shoot();
        }
    }
}
