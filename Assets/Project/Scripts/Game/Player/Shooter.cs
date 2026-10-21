using UnityEngine;

[RequireComponent (typeof(IProjectileSpawner))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private DroneWeapon _weapon;
    [SerializeField] private float _delay = 0.1f;

    private float _lastShootTime = float.MinValue;
    private IProjectileSpawner _spawner;

    public float Delay => _delay;
    public float TimeBeforeShoot
    {
        get
        {
            if (CanShoot() == false)
                return _lastShootTime + _delay - Time.time;
            else
                return 0f;
        }
    }

    private void Awake()
    {
        _spawner = GetComponent<IProjectileSpawner>();
    }

    private void Start()
    {
        _weapon.Initialize(_spawner);
    }

    public void Shoot()
    {
        if (CanShoot() == false)
            return;

        _lastShootTime = Time.time;
        _weapon.Shoot();
    }

    private bool CanShoot()
    {
        return _lastShootTime + _delay < Time.time;
    }
}