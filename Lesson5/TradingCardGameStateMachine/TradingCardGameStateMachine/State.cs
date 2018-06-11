namespace TradingCardGameStateMachine
{
    public interface State
    {
        void EnterState();
        void UpdateState();
        void ExitState();
    }
}
