using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineCardGame
{
    class IngameState : IState
    {
        public void StateEnter()
        {
            var ingameStateMachine = new IngameStateMachine();
            ingameStateMachine.ChangeState(new Player1Turn());
        }

        public void StateExit()
        {
            throw new NotImplementedException();
        }

        public void StateUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
