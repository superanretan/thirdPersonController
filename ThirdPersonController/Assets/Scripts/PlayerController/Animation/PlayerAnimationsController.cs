using System;
using PlayerController.Interfaces;
using UnityEngine;
using Zenject;

namespace PlayerController.Animation
{
    public class PlayerAnimationsController : MonoBehaviour, IPlayerAnimationsController
    {
        private Animator _animator;
       
        public void SetupControler(Animator animator) 
        {
            _animator = animator;
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
        
        public void SetPlayerAnimationWalkSpeed(float speed)
        {
          
            if (_animator != null)
            {
                _animator.SetFloat("Vertical", speed);
             //   _animator.SetLayerWeight(_idleLayerIndex, speed <= 0.01f ? 1 : 0);
            }
        }
    
    }
}
