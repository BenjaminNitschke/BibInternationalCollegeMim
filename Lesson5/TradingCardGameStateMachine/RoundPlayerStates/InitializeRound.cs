namespace TradingCardGameStateMachine.RoundPlayerStates
{
	public class InitializeRound : RoundPlayerState
	{
		public override void Update(Player active, Player other, Round round)
		{
			round.State = new SelectCard();
		}
	}
}