using System;
using UnityEngine;

namespace PlayerController.Interfaces
{
    public interface IPlayerInput
    {
        public event Action<Vector2> MoveInput;
      //  public event Action<Vector2> CameraRotationInput;
        public event Action<bool> PlayerSprint;
    }
}
