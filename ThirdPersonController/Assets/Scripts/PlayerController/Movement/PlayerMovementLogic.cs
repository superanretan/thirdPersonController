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
            var input = MoveVector();
            if (input.sqrMagnitude > 0)
                input.Normalize();

            // Obliczenie kierunku ruchu na podstawie kamery
            Vector3 movement = cameraTransform.forward * input.y + cameraTransform.right * input.x;
            movement.y = 0; // ignorujemy ruch w osi Y
            movement.Normalize();

            // Aktualizacja animacji – np. prędkość biegu
            SetPlayerAnimationVerticalValue?.Invoke(input.magnitude);
    
            // Obliczenie prędkości ruchu i przesunięcie postaci
            Vector3 newVelocity = movement * GetPlayerSpeed();
            _characterController.Move(newVelocity * Time.deltaTime);
        }

        public override void Update()
        {
            base.Update();
            HandleRotation();
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