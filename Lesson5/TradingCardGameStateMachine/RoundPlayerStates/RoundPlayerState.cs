namespace TradingCardGameStateMachine.RoundPlayerStates
{
	public abstract class RoundPlayerState
	{
		public abstract void Update(Player active, Player other, Round round);
	}
}