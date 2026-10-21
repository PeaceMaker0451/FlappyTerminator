using UnityEngine;
using Zenject;

public class CommonGameScenarioInstaller : MonoInstaller
{
    [SerializeField] private CommomGameSenario _gameSenario;

    public override void InstallBindings()
    {
        Container.Bind<IGameScenario>().FromInstance(_gameSenario);
    }
}