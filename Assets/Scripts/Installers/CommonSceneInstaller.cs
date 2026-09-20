using UnityEngine;
using Zenject;

public class CommonSceneInstaller : MonoInstaller
{
    [SerializeField] private InputProvider _inputProvider;
    [SerializeField] private CommomGameSenario _gameSenario = new(); 
    
    public override void InstallBindings()
    {
        Container.Bind<IInputProvider>().FromInstance(_inputProvider);
        Container.Bind<IGameScenario>().FromInstance(_gameSenario);
    }
}