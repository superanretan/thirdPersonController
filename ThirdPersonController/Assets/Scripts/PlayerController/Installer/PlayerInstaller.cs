using PlayerController.Animation;
using PlayerController.Interfaces;
using PlayerController.Movement;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private GameObject playerParent;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerAnimationsController>().FromComponentInChildren(playerParent)
            .AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerInputController>().FromComponentInChildren(playerParent).AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerMovementController>().FromComponentInChildren(playerParent).AsSingle();

    }
}
