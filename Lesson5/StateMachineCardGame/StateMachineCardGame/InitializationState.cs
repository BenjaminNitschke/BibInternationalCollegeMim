using System;

namespace StateMachineCardGame
{
    class InitializationState : IState
    {
        public void StateEnter()
        {
            Program.InitializeGame();
        }

        public void StateExit()
        {
            //throw new NotImplementedException();
        }

        public void StateUpdate()
        {
            //throw new NotImplementedException();
        }
    }
}
