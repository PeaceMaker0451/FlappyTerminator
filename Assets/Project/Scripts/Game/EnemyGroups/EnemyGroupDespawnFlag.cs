using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyGroupDespawnFlag : MonoBehaviour
{
    private Action _onDespawned;
    
    public void SetDespawnAction(Action despawnAction)
    {
        _onDespawned = despawnAction;
    }
    
    public void Despawn()
    {
        Debug.Log($"Флаг деспавна вызван");
        if (_onDespawned == null)
            throw new NullReferenceException("Despawn action не установлен");

        _onDespawned();
    }
}