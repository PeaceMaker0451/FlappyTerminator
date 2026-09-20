using Assets.Scripts.Game;
using System;
using UnityEngine;

public class EnemyGroupSpawnersContainer : MonoBehaviour
{
    [SerializeField] private EnemyGroupSpawner[] _easySpawners;
    [SerializeField] private EnemyGroupSpawner[] _mediumSpawners;
    [SerializeField] private EnemyGroupSpawner[] _hardSpawners;

    private void Start()
    {
        if (_easySpawners == null || _easySpawners.Length == 0)
            throw new Exception("Легкие спавнеры не готовы");

        if (_mediumSpawners == null || _easySpawners.Length == 0)
            throw new Exception("Средние спавнеры не готовы");

        if (_hardSpawners == null || _easySpawners.Length == 0)
            throw new Exception("Тяжелые спавнеры не готовы");
    }

    public void Spawn(EnemyType type, float speed, Vector2 position)
    {
        switch (type)
        {
            case EnemyType.RandomEasy:
                GetRandomSpawner(_easySpawners).SpawnParticle(speed, position);
                break;

            case EnemyType.RandomMedium:
                GetRandomSpawner(_mediumSpawners).SpawnParticle(speed, position);
                break;

            case EnemyType.RandomHard:
                GetRandomSpawner(_hardSpawners).SpawnParticle(speed, position);
                break;
        }
    }

    private EnemyGroupSpawner GetRandomSpawner(EnemyGroupSpawner[] spawners)
    {
        int randomIndex = UnityEngine.Random.Range(0, spawners.Length);
        return spawners[randomIndex];
    }
}