using System;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    private EnemyGroupDespawnFlag _despawnFlag;
    private WorldMover[] _worldMovers;
    private IResetable[] _resetables;
    private Action _onSuspended;

    private void Awake()
    {
        _worldMovers = GetComponentsInChildren<WorldMover>();
        _resetables = GetComponentsInChildren<IResetable>();

        _despawnFlag = GetComponentInChildren<EnemyGroupDespawnFlag>();
        if (_despawnFlag == null)
            throw new Exception("Флаг деспавна не создан");
    }

    public void Initialize(Action onSuspended)
    {
        _despawnFlag.SetDespawnAction(onSuspended);
    }

    public void StartOver()
    {
        foreach (var resetable in _resetables)
            resetable.ResetComponent();

        gameObject.SetActive(true);
    }
}
