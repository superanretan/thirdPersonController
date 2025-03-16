using System;
using PlayerController.Animation;
using PlayerController.Interfaces;
using PlayerController.Movement;
using UnityEngine;
using Zenject;

namespace PlayerController.Context
{
    public class PlayerMovementContext : MonoBehaviour
    {
        private GameObject _playerParent;
        private IPlayerAnimationsController _playerAnimationsController;
        private IPlayerMovementController _playerMovementController;
        private IPlayerInput _playerInput;
        
        
        [Inject]
        public void Construct(IPlayerAnimationsController playerAnimationsController,
            IPlayerInput playerInput,
            IPlayerMovementController playerMovementController)
        {
            _playerAnimationsController = playerAnimationsController;
            _playerMovementController = playerMovementController;
            _playerInput = playerInput;
            _playerParent = transform.gameObject;
            SetupMoveActions();
            SetupMovementController();
        }

        private void SetupMovementController()
        {
            _playerMovementController.SetupMovementController(_playerParent);
        }
        
        private void SetupMoveActions()
        {
            _playerInput.MoveInput += PlayerInputOnMoveInput;
            _playerMovementController.SetPlayerAnimationVerticalValue +=
                _playerAnimationsController.SetPlayerAnimationWalkSpeed;
        }

        private void OnDisable()
        {
            _playerInput.MoveInput -= PlayerInputOnMoveInput;
            _playerMovementController.SetPlayerAnimationVerticalValue -=
                _playerAnimationsController.SetPlayerAnimationWalkSpeed;
        }

        private void PlayerInputOnMoveInput(Vector2 obj)
        {
            _playerMovementController.OnMoveInput(obj);
        }
    }
}
