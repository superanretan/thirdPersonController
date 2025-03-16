using PlayerController.Interfaces;
using PlayerController.Movement;
using UnityEngine;

namespace PlayerController.StateManager.PlayerStates
{
    [CreateAssetMenu (menuName = "PlayerStateBehaviours/PlayerWalkState")]
    public class PlayerWalkState : BaseState
    {
        private IPlayerMovementController _playerMovement;
        public override void EnterState(StateManagerBase sender)
        {
            var playerMovementController = sender.GetComponentInChildren<PlayerMovementController>();

            if (playerMovementController is IPlayerMovementController pmc)
            {
                _playerMovement = pmc;
            }
        }

        public override void ExitState(StateManagerBase sender)
        {
    
        }

        public override void UpdateState(StateManagerBase sender)
        {
            if (_playerMovement == null) return;
            
            if (_playerMovement.MoveVector().magnitude == 0)
                _playerMovement.SwitchPlayerState(_playerMovement.PlayerIdleState());
            else if(_playerMovement.MoveAmount()<= 0.5f)
                _playerMovement.HandleMovement();
            else if(_playerMovement.MoveAmount()> 0.5f)
                _playerMovement.SwitchPlayerState(_playerMovement.PlayerRunState());
        }
    }
}
