using UnityEngine;
using Zenject;

public class CommonSceneInstaller : MonoInstaller
{
    [RequireInterface(typeof(IInputProvider))]
    [SerializeField] private MonoBehaviour _inputProvider;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private BulletSpawner _radioDefenseSpawner;
    [SerializeField] private World _world;
    
    
    public override void InstallBindings()
    {
        Container.Bind<IInputProvider>().FromInstance(_inputProvider as IInputProvider);
        Container.Bind<BulletSpawner>().WithId(ProjectileTypes.Bullets).FromInstance(_bulletSpawner);
        Container.Bind<BulletSpawner>().WithId(ProjectileTypes.RadioDefense).FromInstance(_radioDefenseSpawner);
        Container.Bind<World>().FromInstance(_world);
    }
}