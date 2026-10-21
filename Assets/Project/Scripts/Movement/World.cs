using System;
using System.Collections;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private float _changeSpeed = 5f;
    
    public event Action<float> WorldSpeedChanged;

    public float Speed {  get; private set; }

    private Coroutine _speedRoutine;

    public void SetWorldSpeed(float speed)
    {
        if (_speedRoutine != null)
            StopCoroutine(_speedRoutine);

        _speedRoutine = StartCoroutine(LerpSpeed(speed));
    }

    private void UpdateWorldSpeed(float speed)
    {
        Speed = speed;
        WorldSpeedChanged?.Invoke(Speed);
    }

    private IEnumerator LerpSpeed(float targetSpeed)
    {
        while(Speed != targetSpeed)
        {
            UpdateWorldSpeed(Mathf.MoveTowards(Speed, targetSpeed, _changeSpeed * Time.deltaTime));
            yield return null;
        }
    }
}
