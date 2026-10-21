using UnityEngine;

public interface IProjectileSpawner
{
    public IProjectile Shoot(Vector2 position, Vector2 direction);
}
