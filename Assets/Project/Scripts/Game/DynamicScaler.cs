using UnityEngine;

public class DynamicScaler : MonoBehaviour, IResetable
{
    [SerializeField] private float _time;
    [SerializeField] private Vector3 _targetScale;

    private Vector3 _baseScale;
    private float _startTime;

    private void Awake()
    {
        _baseScale = transform.localScale;
        _startTime = Time.time;
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(_baseScale, _targetScale, (Time.time - _startTime) / _time);
    }

    public void ResetComponent()
    {
        _startTime = Time.time;
    }
}