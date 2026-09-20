using System;
using UnityEngine;

[Serializable]
public class CommomGameSenario : IGameScenario
{
    [SerializeField] private int _maxDifficulty = 200;
    [SerializeField] private int _mediumEnemiesThreshold = 50;
    [SerializeField] private int _hardEnemiesThreshold = 100;

    [SerializeField] private float _minSpeed = 3f;
    [SerializeField] private float _maxSpeed = 10f;

    [SerializeField] private int _currentDifficulty = 0;
    
    public EnemyParameters GetNextEnemy()
    {
        float speed = Mathf.Lerp(_minSpeed, _maxSpeed, (float)_currentDifficulty / (float)_maxDifficulty);
        EnemyType type;

        if (_currentDifficulty > _hardEnemiesThreshold)
            type = EnemyType.RandomHard;
        else if (_currentDifficulty > _mediumEnemiesThreshold)
            type = EnemyType.RandomMedium;
        else 
            type = EnemyType.RandomEasy;

        _currentDifficulty++;

        return new(type, speed);
    }
}
