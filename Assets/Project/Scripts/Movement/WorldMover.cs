using System;
using UnityEngine;
using Zenject;

public class WorldMover : MonoBehaviour
{
    private World _world;
    private Vector2 _direction = Vector2.left;
    private float _speed = 1;

    [Inject]
    private void Inject(World world)
    {
        _world = world;
        _world.WorldSpeedChanged += SetWorldSpeed;
    }

    private void Start()
    {
        if (_world == null)
            throw new NullReferenceException("World компонент не установлен");

        SetWorldSpeed(_world.Speed);
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }

    private void SetWorldSpeed(float speed)
    {
        _speed = speed;
    }
}
