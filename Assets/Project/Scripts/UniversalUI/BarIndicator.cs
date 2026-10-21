using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class BarIndicator : NumberDisplayField
{
    private Slider _slider;
    private float _value;
    private float _maxValue;

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
        _slider.maxValue = _maxValue;
        _slider.value = _value;
    }
}
