using UnityEngine;

namespace PlayerController.Interfaces
{
    public interface IPlayerInput
    {
       public Vector2 MoveInput { get; }
       public Vector2 CameraRotationInput { get; }
    }
}
