using System;
using PlayerController.StateManager;
using UnityEngine;

namespace PlayerController.Interfaces
{
    public interface IPlayerMovementController
    {
        public void SetupMovementController(GameObject playerParent);
        public void OnMoveInput(Vector2 moveInput);

        public Vector2 MoveVector();
        public float MoveAmount();
        public void HandleMovement();
        public void SwitchPlayerState(BaseState state);

        public event Action<float> SetPlayerAnimationVerticalValue;
        
        public BaseState PlayerIdleState();
        public BaseState PlayerWalkState();
        public BaseState PlayerRunState();
    }
}