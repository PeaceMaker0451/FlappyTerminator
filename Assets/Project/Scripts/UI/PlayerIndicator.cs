using UnityEngine;
using Zenject;

public class PlayerIndicator : MonoBehaviour
{
    [SerializeField] private NumberDisplayField _jumpReadyField;
    [SerializeField] private NumberDisplayField _shootReadyField;
    [SerializeField] private NumberDisplayField _healthField;

    private Player _player;
    private Health _health;

    [Inject]
    private void Inject(Player player)
    {
        _player = player;
        _health = player.GetComponent<Health>();
    }

    private void Start()
    {
        if (_player == null)
            throw new System.Exception("Player не установлен");
        
        if (_health == null)
            throw new System.Exception("Health не получен");

        _jumpReadyField.SetMaxValue(_player.JumpDelay);
        _shootReadyField.SetMaxValue(_player.ShootDelay);

        _health.Changed += UpdateHealth;
        UpdateHealth();
    }

    private void OnDestroy()
    {
        _health.Changed -= UpdateHealth;
    }

    private void Update()
    {
        _shootReadyField.SetValue(_player.ShootDelay - _player.ShootReadyTime);
        _jumpReadyField.SetValue(_player.JumpDelay - _player.JumpReadyTime);
    }

    private void UpdateHealth()
    {
        _healthField.SetMaxValue(_health.MaxPoints);
        _healthField.SetValue(_health.Points);
    }
}
