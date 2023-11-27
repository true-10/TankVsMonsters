using TankVsMonsters.Characters;
using UnityEngine;
using Zenject;

public class BattleSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<BattleUnitManager>().AsSingle();
    }
}