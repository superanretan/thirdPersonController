using PlayerController.Interfaces;
using UnityEngine;

namespace PlayerController.Movement
{
    public class PlayerInputManager : MonoBehaviour, IPlayerInput
    {
        public Vector2 MoveInput { get; private set; }
        public Vector2 CameraRotationInput { get; private set; }

        private PlayerInputActions _playerInputActions;

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();

            _playerInputActions.PlayerMovement.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
            _playerInputActions.PlayerMovement.Move.canceled += ctx => MoveInput = Vector2.zero;

        
            _playerInputActions.CameraMovement.CameraRotation.performed += ctx => CameraRotationInput = ctx.ReadValue<Vector2>();
            _playerInputActions.CameraMovement.CameraRotation.canceled += ctx => CameraRotationInput = Vector2.zero;
        }

        private void OnEnable()
        {
            _playerInputActions.Enable();
        }

        private void OnDisable()
        {
            _playerInputActions.Disable();
        }

        private void OnDestroy()
        {
            _playerInputActions.Dispose();
        }
    }
}
