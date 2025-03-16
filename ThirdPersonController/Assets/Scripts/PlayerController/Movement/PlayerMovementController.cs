using System;
using PlayerController.Interfaces;
using PlayerController.StateManager;
using UnityEngine;

namespace PlayerController.Movement
{
    public partial class PlayerMovementController: StateManagerBase, IPlayerMovementController
    {
        private void Start()
        {
            SetupStartState(PlayerIdleState());
        }

        public void SetupMovementController(GameObject playerParent)
        {
            _characterController = playerParent.GetComponentInChildren<CharacterController>();
        }
        
        public void SwitchPlayerState(BaseState state)
        {
            SwitchState(state);
        }

        public override void SetupStartState(BaseState startState)
        {
            var stateNew = Instantiate(startState) as BaseState;
            CurrentState = stateNew;
            CurrentState.EnterState(this);
        }

        public override void SetupStartStateValue()
        {
          
        }
    }
}
