using PlayerController.Interfaces;
using PlayerController.Movement;
using UnityEngine;

namespace PlayerController.StateManager.PlayerStates
{
    [CreateAssetMenu(menuName = "PlayerStateBehaviours/PlayerIdleState")]
    public class PlayerIdleState : BaseState
    {
        private IPlayerMovementController _playerMovement;

        public override void EnterState(StateManagerBase sender)
        {
            var playerMovementController = sender.GetComponentInChildren<PlayerMovementController>();

            if (playerMovementController is IPlayerMovementController pmc)
            {
                _playerMovement = pmc;
            }
            _playerMovement.StopAnimation();
        }

        public override void ExitState(StateManagerBase sender)
        {
        }

        public override void UpdateState(StateManagerBase sender)
        {
            if (_playerMovement.MoveVector().magnitude != 0)
                _playerMovement.SwitchPlayerState(_playerMovement.PlayerWalkState());
        }
    }
}