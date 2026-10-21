using UnityEngine;

public class EnemyGroupPartResetPositionFixer : MonoBehaviour, IResetable
{
    private Vector3 _position;

    private void Awake()
    {
        RememberPosition();
    }

    public void ResetComponent()
    {
        transform.localPosition = _position;
    }

    private void RememberPosition()
    {
        _position = transform.localPosition;
    }
}