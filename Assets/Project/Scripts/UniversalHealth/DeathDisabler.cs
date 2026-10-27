using UnityEngine;

[RequireComponent(typeof(LifeState))]
public class DeathDisabler : MonoBehaviour
{
    private LifeState _lifeState;

    private IDisableOnDeath[] _components;

    private void Awake()
    {
        _lifeState = GetComponent<LifeState>();
        _lifeState.Died += OnDied;

        _components = GetComponentsInChildren<IDisableOnDeath>();
    }

    private void OnDestroy()
    {
        _lifeState.Died -= OnDied;
    }

    private void OnDied()
    {
        foreach (var component in _components)
            component.enabled = false;
    }

    public void EnableBack()
    {
        foreach (var component in _components)
            component.enabled = true;
    }
}
