using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineCardGame
{
    class StateMachine<T> where T : IState
    {
        private T currentState;

        public T CurrentState
        {
            get { return this.currentState; }
        }

        public void ChangeState(T newState)
        {
            if (currentState != null)
            {
                currentState.StateExit();
            }

            currentState = newState;

            currentState.StateEnter();
        }

        public void UpdateState()
        {
            currentState.StateUpdate();
        }

    }
}
}
