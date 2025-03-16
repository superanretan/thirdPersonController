using System;
using PlayerController.Interfaces;
using UnityEngine;
using Zenject;

namespace PlayerController.Animation
{
    public class PlayerAnimationsController : MonoBehaviour, IPlayerAnimationsController
    {
        private Animator _animator;
       
        public void SetupControler(Animator animator) {
            _animator = animator;
        }

       public void OnMoveInput(Vector2 moveInput)
       {
           PlayerInputOnMoveInput(moveInput);
       }

       public void OnPlayerSprint(bool sprinting)
       {
           
       }

       public void OnPlayerJump()
       {
           
       }

       private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
        }
        
        
        private void PlayerInputOnMoveInput(Vector2 onMoveInput)
        {
            _animator.SetFloat("Vertical", onMoveInput.magnitude);
        }

    
    }
}
