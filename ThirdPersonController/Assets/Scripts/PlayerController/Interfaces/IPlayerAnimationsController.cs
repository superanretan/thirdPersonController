using System;
using UnityEngine;

namespace PlayerController.Interfaces
{
    public interface IPlayerAnimationsController
    {
        public void SetupControler(Animator animator);
        public void SetPlayerAnimationWalkSpeed(float speed);
        public void OnPlayerSprint(bool sprinting);
        public void OnPlayerJump();
    }
}
