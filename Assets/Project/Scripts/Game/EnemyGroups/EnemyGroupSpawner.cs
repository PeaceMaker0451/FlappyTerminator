using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game
{
    public class EnemyGroupSpawner : Spawner<EnemyGroup>
    {
        private DiContainer _container;

        [Inject]
        private void Inject(DiContainer container)
        {
            _container = container;
        }

        public void SpawnParticle(Vector2 position)
        {
            var group = Spawn();
            group.StartOver();
            group.transform.position = position;
            Debug.Log($"{group.name} - спавн");
        }

        protected override void DespawnParticle(EnemyGroup particle)
        {
            Debug.Log($"{particle.name} - деспавн");
            particle.gameObject.SetActive(false);
        }

        protected override void InitializeParticle(EnemyGroup particle, Action despawnAction)
        {
            Debug.Log($"{particle.name} - инициализация");
            _container.InjectGameObject(particle.gameObject);
            particle.Initialize(despawnAction);
        }
    }
}