using Assets.Scripts.Game;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupSpawnersContainer : MonoBehaviour
{
    [SerializeField] private EnemyGroupSpawner[] _easySpawners;
    [SerializeField] private EnemyGroupSpawner[] _mediumSpawners;
    [SerializeField] private EnemyGroupSpawner[] _hardSpawners;

    private Dictionary<EnemyType, EnemyGroupSpawner[]> _spawners;

    private void Awake()
    {
        _spawners = new();
        
        if (_easySpawners == null || _easySpawners.Length == 0)
            throw new Exception("Легкие спавнеры не готовы");

        _spawners[EnemyType.RandomEasy] = _easySpawners;

        if (_mediumSpawners == null || _easySpawners.Length == 0)
            throw new Exception("Средние спавнеры не готовы");

        _spawners[EnemyType.RandomMedium] = _mediumSpawners;

        if (_hardSpawners == null || _easySpawners.Length == 0)
            throw new Exception("Тяжелые спавнеры не готовы");

        _spawners[EnemyType.RandomHard] = _hardSpawners;
    }

    public void Spawn(EnemyType type, Vector2 position)
    {
        GetRandomSpawner(_spawners[type]).SpawnParticle(position);
    }

    private EnemyGroupSpawner GetRandomSpawner(EnemyGroupSpawner[] spawners)
    {
        int randomIndex = UnityEngine.Random.Range(0, spawners.Length);
        return spawners[randomIndex];
    }
}