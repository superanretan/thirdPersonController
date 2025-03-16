using System;
using UnityEngine;

namespace PlayerController.Movement
{
    public partial class PlayerMovementController
    {
        public event Action<float> SetPlayerAnimationVerticalValue;
        public void OnMoveInput(Vector2 moveInput)
        {
            moveVector = moveInput;
        }
        
        public void HandleMovement()
        {
            var movementInput = MoveVector();
            movementInput.Normalize();

            var movement = transform.forward * movementInput.y +
                           transform.right * movementInput.x;
            
            movement.Normalize();
            SetPlayerAnimationVerticalValue?.Invoke(movementInput.magnitude);
            var newVelo = transform.forward + movement * GetPlayerSpeed(); 
            _characterController.Move(newVelo * Time.deltaTime);
        }

        
        private void HandleRotation()
        {
            var cameraForward = cameraTransform.forward;
            var cameraRight = cameraTransform.right;

            var targetDirection = cameraForward * MoveVector().y + cameraRight * MoveVector().x;
            targetDirection.Normalize();
            targetDirection.y = 0;

            if (targetDirection == Vector3.zero)
                targetDirection = transform.forward;


            var targetRotation = Quaternion.LookRotation(targetDirection);
            var playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.rotation = playerRotation;
        }
        
        public void StopAnimation()
        {
            SetPlayerAnimationVerticalValue?.Invoke(0);
        }
        
        private float GetPlayerSpeed() //return player speed based on current player state
        {
            var speed = 0.0f;
            if (CurrentState.name.Contains(playerWalkState.name) )
                speed = walkSpeed;

            if (CurrentState.name.Contains(playerRunState.name))
                speed = runSpeed;

            if (CurrentState.name.Contains(playerIdleState.name))
                speed = 0;

            return speed;
        }
    }
}