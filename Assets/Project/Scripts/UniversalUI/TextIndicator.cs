using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextIndicator : NumberDisplayField
{
    private TMP_Text _text;
    private float _value;
    private float _maxValue;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
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
        _text.text = $"{_value}/{_maxValue}";
    }
}
