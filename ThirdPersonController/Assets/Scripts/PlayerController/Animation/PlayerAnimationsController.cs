using System;
using PlayerController.Interfaces;
using UnityEngine;
using Zenject;

namespace PlayerController.Animation
{
    public class PlayerAnimationsController : MonoBehaviour
    {
        private Animator _animator;
        private IPlayerInput _playerInput;

        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        [Inject]
        public void Construct(Animator animator, IPlayerInput playerInput) {
            _animator = animator;
            _playerInput = playerInput;
            
        }

        private void SetupInputActions()
        {
            _playerInput.MoveInput += PlayerInputOnMoveInput;
        }

        private void PlayerInputOnMoveInput(Vector2 onMoveInput)
        {
            _animator.SetFloat("Vertical", onMoveInput.magnitude);
        }
    }
}
