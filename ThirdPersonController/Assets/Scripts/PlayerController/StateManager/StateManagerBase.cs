using UnityEngine;
using UnityEngine.Serialization;

namespace PlayerController.StateManager
{
    public abstract class StateManagerBase : MonoBehaviour
    {
        [SerializeField] private BaseState currentState;
        private BaseState _newState;

        public BaseState CurrentState
        {
            get => currentState;
            set => currentState = value;
        }
        
        public abstract void SetupStartState(BaseState startState);
        
        public abstract void SetupStartStateValue();
        
        public virtual void Update()
        {
            if (currentState != null)
                currentState.UpdateState(this);
        }
        
        public virtual void SwitchState(ScriptableObject state) //switch for player  states simple state machine
        {
            var stateNew = Instantiate(state) as BaseState;
            _newState = stateNew;
            currentState?.ExitState(this);
            DestroyImmediate(currentState);
            currentState = _newState;
            currentState.EnterState(this);
        }

        private void OnDestroy()
        {
            currentState.ExitState(this);
            currentState = null;
        }
    }
}
