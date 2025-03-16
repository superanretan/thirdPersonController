using System;
using UnityEngine;

namespace PlayerController.Movement
{
    public abstract partial class PlayerMovementController
    {
        public void HandleMovement()
        {
            var movementInput = MoveVector();
            movementInput.Normalize();

            var movement = transform.forward * movementInput.y +
                           transform.right * movementInput.x;

            movement.y = 0;

            movement.Normalize();

            var moveMagnitude = MoveVector().magnitude;
            if (moveMagnitude > 0 && moveMagnitude < 0.2f)
                moveMagnitude = 0.2f;


            SetPlayerAnimationVerticalValue?.Invoke(moveMagnitude);
            
            var newVelo = transform.forward * moveMagnitude * GetPlayerSpeed(); 
          //  newVelo.y = adjustedVelocityY;
            _characterController.Move(newVelo * Time.deltaTime);
        //    _playerVelocity = 1;
        }

        public event Action<float> SetPlayerAnimationVerticalValue;


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