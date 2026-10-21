using System;
using UnityEngine;

public interface IDroneWeapon
{
    public Transform transform { get; }
    public float CurrentAngle { get; }
    public void RotateAt(float angle);
    public void Shoot();
}
