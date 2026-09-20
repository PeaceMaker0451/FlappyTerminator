using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersCamera : MonoBehaviour
{
    [SerializeField] Transform _targetTransform;
    [SerializeField] private float _maxYPosition = 8;
    [SerializeField] private float _minYPosition = -8;
    [SerializeField] private float _floatSpeed = 0.3f;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _targetTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = new(_targetTransform.position.x + _offset.x,
            Mathf.Clamp(_targetTransform.position.y, _minYPosition, _maxYPosition),
            _targetTransform.position.z + _offset.z);


        transform.position = Vector3.Lerp(transform.position, targetPosition, _floatSpeed);
    }
}
