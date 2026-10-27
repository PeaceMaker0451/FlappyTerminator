using UnityEngine;
using Zenject;
public class Drone : MonoBehaviour, IDisableOnDeath
{
    [SerializeField] private ProjectileTypes _projectileType = ProjectileTypes.Bullets;
    [SerializeField] private WeaponStrategy _shootStrategy;
    [SerializeField] private DroneWeapon _weapon;
    
    private IProjectileSpawner _shooter;
    private Player _player;

    [Inject]
    private void Inject(Player player, [Inject(Id = ProjectileTypes.Bullets)] BulletSpawner bulletSpawner, [Inject(Id = ProjectileTypes.RadioDefense)] BulletSpawner radioSpawner)
    {
        if(_projectileType == ProjectileTypes.Bullets)
            _shooter = bulletSpawner;
        else
            _shooter = radioSpawner;

            _player = player;
    }

    private void Start()
    {
        _weapon.Initialize(_shooter);
    }

    private void Update()
    {
        if(_shootStrategy != null && _player != null)
        {
            _shootStrategy.Tick(_player.transform, _weapon);
        }
    }
}
