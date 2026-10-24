using UnityEngine;

[RequireComponent(typeof(LifeState))]
public class DeathActer : MonoBehaviour
{
    [SerializeField] private bool _recursive = false;

    private LifeState _lifeState;

    private void Awake()
    {
        _lifeState = GetComponent<LifeState>();
        _lifeState.Died += OnDied;
    }

    private void OnDestroy()
    {
        _lifeState.Died -= OnDied;
    }

    private void OnDied()
    {
        IActOnDeath[] components;
        
        if (_recursive)
            components = GetComponentsInChildren<IActOnDeath>();
        else
            components = GetComponents<IActOnDeath>();

        foreach (var component in components)
                component.OnDied();
    }
}