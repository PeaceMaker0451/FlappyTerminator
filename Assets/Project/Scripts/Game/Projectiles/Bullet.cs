using System;
using UnityEngine;

[RequireComponent(typeof(LinearMover), typeof(DamageOnEnter))]
[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour, IProjectile
{
    [SerializeField] private float _dieTime = 15;
    [SerializeField] private bool _shouldDestroyOnTouch = true;

    private IResetable[] _resetables;
    private LinearMover _linearMover;
    private DamageOnEnter _damageOnEnter;
    private Collider _collider;

    private Action _onDestroy;
    private float _shootTime;

    private void Awake()
    {
        _resetables = GetComponentsInChildren<IResetable>();
        _linearMover = GetComponent<LinearMover>();
        _damageOnEnter = GetComponent<DamageOnEnter>();
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;

        _damageOnEnter.Damaged += OnDamage;
    }

    private void Update()
    {
        if (Time.time > _shootTime + _dieTime)
            Clear();
    }

    public void Initialize(Action onDestory)
    {
        _onDestroy = onDestory;
    }

    public void Shoot(Vector2 direction)
    {
        foreach (var resetable in _resetables)
            resetable.ResetComponent();

        _linearMover.SetDirection(direction);
        _shootTime = Time.time;
    }

    public void Clear()
    {
        _onDestroy?.Invoke();
    }

    private void OnDamage()
    {
        if(_shouldDestroyOnTouch)
            Clear();
    }
}
