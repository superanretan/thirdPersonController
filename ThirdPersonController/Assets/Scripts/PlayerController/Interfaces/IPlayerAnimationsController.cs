using System;
using UnityEngine;

namespace PlayerController.Interfaces
{
    public interface IPlayerAnimationsController
    {
        public void SetupControler(Animator animator, Action<Vector2> onMoveInput);
    }
}
