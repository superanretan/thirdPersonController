using PlayerController.Animation;
using PlayerController.Interfaces;
using PlayerController.Movement;
using UnityEngine;
using Zenject;

namespace PlayerController.Context
{
    public class PlayerMovementContext : MonoBehaviour
    {
        [SerializeField] private GameObject playerParent;
        private IPlayerAnimationsController _playerAnimationsController;
        private IPlayerMovementController _playerMovementController;
        private IPlayerInput _playerInput;
        
        
        [Inject]
        public void Contruct(IPlayerAnimationsController playerAnimationsController,
            IPlayerInput playerInput,
            IPlayerMovementController playerMovementController)
        {
            _playerAnimationsController = playerAnimationsController;
            _playerMovementController = playerMovementController;
            _playerInput = playerInput;
            SetupMoveInputActions();
            SetupMovementController();
        }

        private void SetupMovementController()
        {
            _playerMovementController.SetupMovementController(playerParent);
        }
        
        private void SetupMoveInputActions()
        {
            _playerInput.MoveInput += PlayerInputOnMoveInput;
        }

        private void PlayerInputOnMoveInput(Vector2 obj)
        {
            _playerAnimationsController.OnMoveInput(obj);
            _playerMovementController.OnMoveInput(obj);
        }
    }
}
