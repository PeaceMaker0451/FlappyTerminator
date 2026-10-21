using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LegacyTextIndicator : NumberDisplayField
{
    private Text _text;
    private float _value;
    private float _maxValue;

    private void Awake()
    {
        _text = GetComponent<Text>();
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
