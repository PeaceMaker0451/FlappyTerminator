using System;
using UnityEngine;

[RequireComponent(typeof(FlowMover))]
public class EnemyGroup : MonoBehaviour
{
    private FlowMover _mover;

    private Action _onSuspended;

    private void Awake()
    {
        _mover = GetComponent<FlowMover>();
    }

    public void Initialize(Action onSuspended)
    {
        _onSuspended = onSuspended;
    }

    public void StartOver(float speed)
    {
        _mover.SetSpeed(speed);
        gameObject.SetActive(true);
    }

    public void Suspend()
    {
        _onSuspended?.Invoke();
    }
}
