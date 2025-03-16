using System;
using UnityEngine;

namespace PlayerController.Interfaces
{
    public interface IPlayerAnimationsController
    {
        public void SetupControler(Animator animator);
        public void OnMoveInput(Vector2 moveInput);
        public void OnPlayerSprint(bool sprinting);
        public void OnPlayerJump();
    }
}
