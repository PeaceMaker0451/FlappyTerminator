using UnityEngine;

public class EnemyGroupDespawnZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyGroup>(out var enemyGroup))
            enemyGroup.Suspend();
    }
}