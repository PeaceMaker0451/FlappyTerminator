using UnityEngine;

public class EnemyGroupDespawnZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyGroupDespawnFlag>(out var enemyGroup))
            enemyGroup.Despawn();
    }
}