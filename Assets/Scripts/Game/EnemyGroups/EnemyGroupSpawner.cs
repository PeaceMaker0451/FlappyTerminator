using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class EnemyGroupSpawner : Spawner<EnemyGroup>
    {
        public void SpawnParticle(float speed, Vector2 position)
        {
            var group = Spawn();
            group.StartOver(speed);
            group.transform.position = position;
        }

        protected override void DespawnParticle(EnemyGroup particle) { }

        protected override void InitializeParticle(EnemyGroup particle, Action despawnAction)
        {
            particle.Initialize(despawnAction);
        }
    }
}