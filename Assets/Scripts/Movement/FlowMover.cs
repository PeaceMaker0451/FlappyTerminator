using UnityEngine;

public class FlowMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction = Vector3.left;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
