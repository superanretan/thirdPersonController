using System;
using PlayerController.Interfaces;
using UnityEngine;

namespace PlayerController.Movement
{
    public class PlayerMovementController : MonoBehaviour, IPlayerMovementController
    {
        private CharacterController _characterController;
        
        public void OnMoveInput(Vector2 moveInput)
        {
            
        }
        
        public void SetupMovementController(GameObject playerParent)
        {
            _characterController = playerParent.GetComponentInChildren<CharacterController>();
        }
        
    }
}
