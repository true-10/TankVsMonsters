using System;

namespace TankVsMonsters
{
    public sealed class StateMachine
    {
        public Action<IState> OnStateEnter { get; set; }
        public Action<IState> OnStateExit { get; set; }

        private IState currentState;

        public void Init(IState newState)
        {
            currentState = newState;
            currentState.Enter();
            OnStateEnter?.Invoke(currentState);
        }

        public void SetState(IState newState, Action OnError = null)
        {
            if (newState == null)
            {
                OnError?.Invoke();
                return;
            }

            if (currentState != null)
            {
                currentState.Exit();
                OnStateExit?.Invoke(currentState);
            }
            currentState = newState;
            currentState.Enter();
            OnStateEnter?.Invoke(currentState);
        }

        public void Update()
        {
            if (currentState == null)
            {
                return;
            }
            currentState.Update();
        }      
        
        public void FixedUpdate()
        {
            if (currentState == null)
            {
                return;
            }
            currentState.FixedUpdate();
        }
    }
}
