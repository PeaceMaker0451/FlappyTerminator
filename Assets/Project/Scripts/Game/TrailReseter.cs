using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class TrailReseter : MonoBehaviour, IResetable
{
    private TrailRenderer _trail;

    private void Awake()
    {
        _trail = GetComponent<TrailRenderer>();
    }

    public void ResetComponent()
    {
        _trail.Clear();
    }
}