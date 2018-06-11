using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCardGameStateMachine
{
    public class StateMachine
    {
        private State current;

        public StateMachine()
        {

        }

        public void ChangeState(State newState)
        {
            current.ExitState();
            current = newState;
            current.EnterState();
        }

        public void UpdateState()
        {
            current.UpdateState();
        }
    }
}
