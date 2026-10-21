using UnityEngine;

public abstract class ShootStrategy : MonoBehaviour
{
    public abstract void Tick(Transform player, IDroneWeapon shooter);
}
