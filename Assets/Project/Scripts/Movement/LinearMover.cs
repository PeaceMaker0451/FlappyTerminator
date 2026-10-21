using UnityEngine;

public class LinearMover : MonoBehaviour
{
    [SerializeField] private Vector2 _direction = Vector2.left;
    [SerializeField] private float _speed = 1;
    
    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
}
