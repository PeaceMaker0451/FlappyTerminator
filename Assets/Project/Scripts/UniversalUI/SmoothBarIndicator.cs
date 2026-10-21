using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothBarIndicator : NumberDisplayField
{
    [SerializeField] private float _speed = 20f;

    private Slider _slider;
    private float _value;
    private float _maxValue;
    private Coroutine _updateValueCoroutine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public override void SetValue(float value)
    {
        _value = value;
        UpdateValue();
    }

    public override void SetMaxValue(float value)
    {
        _maxValue = value;
        UpdateValue();
    }

    private void UpdateValue()
    {
        if (_updateValueCoroutine != null)
            StopCoroutine(_updateValueCoroutine);

        _updateValueCoroutine = StartCoroutine(UpdateValueSmooth());
    }

    private IEnumerator UpdateValueSmooth()
    {
        while(_slider.maxValue != _maxValue || _slider.value != _value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _value, _speed * Time.deltaTime);
            _slider.maxValue = Mathf.MoveTowards(_slider.maxValue, _maxValue, _speed * Time.deltaTime);
            
            yield return null;
        }
    }
}