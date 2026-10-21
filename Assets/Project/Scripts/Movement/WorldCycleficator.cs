using UnityEngine;

public class WorldCycleficator : MonoBehaviour
{
    [SerializeField] private float _returnDistance = 50;

    private float _baseXDistance;

    void Start()
    {
        _baseXDistance = transform.position.x;
    }

    void Update()
    {
        if (transform.position.x < _baseXDistance - _returnDistance)
            transform.position = new(
                transform.position.x + _returnDistance,
                transform.position.y,
                transform.position.z);

    }
}
