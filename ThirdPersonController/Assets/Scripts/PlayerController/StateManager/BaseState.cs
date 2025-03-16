using UnityEngine;

namespace PlayerController.StateManager
{
    public abstract class BaseState: ScriptableObject
    {
        public abstract void EnterState(StateManagerBase sender);
        public abstract void ExitState(StateManagerBase sender);
        public abstract void UpdateState(StateManagerBase sender);
    }
}  
