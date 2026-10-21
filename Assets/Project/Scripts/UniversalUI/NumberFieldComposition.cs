using UnityEngine;

public class NumberFieldComposition : NumberDisplayField
{
    [SerializeField] private NumberDisplayField[] _fields;
    
    public override void SetMaxValue(float value)
    {
        foreach (var field in _fields)
            field.SetMaxValue(value);
    }

    public override void SetValue(float value)
    {
        foreach (var field in _fields)
            field.SetValue(value);
    } 
}
