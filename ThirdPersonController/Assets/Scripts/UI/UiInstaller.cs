using UI.Mediators;
using UnityEngine;
using Zenject;

namespace UI.Context
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private GameObject playerUI;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerStatsMediator>().FromComponentsInChildren(playerUI).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerStatsContext>().FromComponentsInChildren(playerUI).AsSingle().NonLazy();
        }
    }
}