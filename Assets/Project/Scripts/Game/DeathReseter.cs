using System.Collections;
using UnityEngine;

[RequireComponent(typeof(DeathDisabler))]
public class DeathReseter : MonoBehaviour, IResetable
{
    private DeathDisabler _disabler;

    private void Awake()
    {
        _disabler = GetComponent<DeathDisabler>();
    }

    public void ResetComponent()
    {
        _disabler.EnableBack();
    }
}