using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FilledImageIndicator : NumberDisplayField
{
    private Image _image;
    private float _value;
    private float _maxValue;

    private void Awake()
    {
        _image = GetComponent<Image>();
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
        _image.fillAmount = _value / _maxValue;
    }
}
