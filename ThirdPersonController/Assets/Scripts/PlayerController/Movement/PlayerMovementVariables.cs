using PlayerController.StateManager;
using UnityEngine;
using UnityEngine.Serialization;

namespace PlayerController.Movement
{
    public partial class PlayerMovementController
    {
        [Header("Player States")]
        [SerializeField] protected BaseState playerIdleState;
        [SerializeField] protected BaseState playerWalkState;
        [SerializeField] protected BaseState playerRunState;
        
        [Header("Movement variables")]
        [SerializeField] private float moveAmount;
        [SerializeField] private Vector2 moveVector;
        [SerializeField] protected float walkSpeed = 10;
        [SerializeField] protected float runSpeed = 20;
        [SerializeField] protected float rotationSpeed = 5f;
        [SerializeField] protected Transform cameraTransform;
        
        private CharacterController _characterController;
        
        
        public float MoveAmount()
        {
            return moveAmount;
        }
        
        public Vector2 MoveVector()
        {
            return moveVector;
        }
        
        public BaseState PlayerIdleState()
        {
            return playerIdleState;
        }

        public BaseState PlayerWalkState()
        {
            return playerWalkState;
        }

        public BaseState PlayerRunState()
        {
            return playerRunState;
        }
    }
}
