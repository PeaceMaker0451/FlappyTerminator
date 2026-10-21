using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(EnemyGroupSpawnersContainer))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private float _spawnMaxOffset;
    [SerializeField] private float _spawnSpace = 5;

    private World _world;
    private EnemyGroupSpawnersContainer _spawners;
    private IGameScenario _gameScenario;
    private CancellationTokenSource _gameTokenSource = new();

    [Inject]
    private void Inject(IGameScenario scenario, World world)
    {
        _gameScenario = scenario;
        _world = world;
    }

    private void Awake()
    {
        _spawners = GetComponent<EnemyGroupSpawnersContainer>();
    }

    private void Start()
    {
        _ = Game(_gameTokenSource.Token);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(new Vector3(transform.position.x, _spawnMaxOffset, 0), new Vector3(transform.position.x, -_spawnMaxOffset, 0), Color.red);
    }

    private async UniTask Game(CancellationToken token)
    {
        while(token.IsCancellationRequested == false)
        {
            var parameters = _gameScenario.GetNextEnemy();
            _spawners.Spawn(parameters.Type, GetRandomSpawnPosition());
            _world.SetWorldSpeed(parameters.Speed);
            await UniTask.WaitForSeconds(_spawnSpace / parameters.Speed, cancellationToken: token);
        }
    }

    private Vector2 GetRandomSpawnPosition()
    {
        return new Vector2(transform.position.x, UnityEngine.Random.Range(-_spawnMaxOffset, _spawnMaxOffset));
    }
}
