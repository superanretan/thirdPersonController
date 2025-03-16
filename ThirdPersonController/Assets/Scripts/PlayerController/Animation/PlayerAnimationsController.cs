using System;
using PlayerController.Interfaces;
using UnityEngine;
using Zenject;

namespace PlayerController.Animation
{
    public class PlayerAnimationsController : MonoBehaviour, IPlayerAnimationsController
    {
        private Animator _animator;
        private event Action<Vector2> _onMoveInput;
        
        public void SetupControler(Animator animator, Action<Vector2> onMoveInput) {
            _animator = animator;
            _onMoveInput = onMoveInput;
            SetupInputActions();
        }
        
        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        private void SetupInputActions()
        {
            _onMoveInput += PlayerInputOnMoveInput;
        }

        private void OnDestroy()
        {
            _onMoveInput -= PlayerInputOnMoveInput;
        }
        
        private void PlayerInputOnMoveInput(Vector2 onMoveInput)
        {
            _animator.SetFloat("Vertical", onMoveInput.magnitude);
        }
     
    }
}
