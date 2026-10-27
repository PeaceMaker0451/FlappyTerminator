using UnityEngine;
using Zenject;

public class CommonGameScenarioInstaller : MonoInstaller
{
    [SerializeField] private CommomGameScenario _gameSenario;

    public override void InstallBindings()
    {
        Container.Bind<IGameScenario>().FromInstance(_gameSenario);
    }
}