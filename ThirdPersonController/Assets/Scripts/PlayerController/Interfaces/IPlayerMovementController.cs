using UnityEngine;

namespace PlayerController.Interfaces
{
    public interface IPlayerMovementController
    {
        public void SetupMovementController(GameObject playerParent);
        public void OnMoveInput(Vector2 moveInput);
    }
}
