using System;
using PlayerController.Interfaces;
using UnityEngine;

namespace PlayerController.Movement
{
    public class PlayerInputController : MonoBehaviour, IPlayerInput
    {
        public event Action<Vector2> MoveInput;
        public event Action<Vector2> CameraRotationInput;
        public event Action<bool> PlayerSprint;

        private PlayerInputActions _playerInputActions;

        private void Awake()
        {
            SetupInputActions();
        }

        private void SetupInputActions()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.PlayerMovement.Move.performed += ctx => MoveInput?.Invoke(ctx.ReadValue<Vector2>());
            _playerInputActions.PlayerMovement.Move.canceled += ctx => MoveInput?.Invoke(Vector2.zero);
            _playerInputActions.CameraMovement.CameraRotation.performed += ctx => CameraRotationInput?.Invoke(ctx.ReadValue<Vector2>());
            _playerInputActions.CameraMovement.CameraRotation.canceled += ctx => CameraRotationInput?.Invoke(Vector2.zero);
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
