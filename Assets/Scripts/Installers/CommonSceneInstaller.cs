using UnityEngine;
using Zenject;

public class CommonSceneInstaller : MonoInstaller
{
    [SerializeField] private InputProvider _inputProvider;
    
    public override void InstallBindings()
    {
        Container.Bind<IInputProvider>().FromInstance(_inputProvider);
    }
}