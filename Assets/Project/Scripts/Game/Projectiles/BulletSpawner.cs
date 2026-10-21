using System;
using UnityEngine;
using Zenject;

public class BulletSpawner : Spawner<Bullet>, IProjectileSpawner
{
    private DiContainer _container;

    [Inject]
    private void Inject(DiContainer container)
    {
        _container = container;
    }
    
    public Bullet Shoot(Vector2 position, Vector2 direction)
    {
        var bullet = base.Spawn();
        bullet.transform.position = position;
        bullet.gameObject.SetActive(true);
        bullet.Shoot(direction);

        return bullet;
    }

    IProjectile IProjectileSpawner.Shoot(Vector2 position, Vector2 direction)
    {
        return Shoot(position, direction);
    }

    protected override void DespawnParticle(Bullet particle)
    {
        particle.gameObject.SetActive(false);
    }

    protected override void InitializeParticle(Bullet particle, Action despawnAction)
    {
        _container.InjectGameObject(particle.gameObject);
        particle.Initialize(despawnAction);
    }
}
