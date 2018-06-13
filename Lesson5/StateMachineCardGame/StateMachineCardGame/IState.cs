namespace StateMachineCardGame
{
    internal interface IState
    {
        void StateEnter();
        void StateUpdate();
        void StateExit();
    }
}