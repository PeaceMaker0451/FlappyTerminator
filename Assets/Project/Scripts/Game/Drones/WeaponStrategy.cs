using UnityEngine;

public abstract class WeaponStrategy : MonoBehaviour
{
    public abstract void Tick(Transform player, IDroneWeapon shooter);
}
