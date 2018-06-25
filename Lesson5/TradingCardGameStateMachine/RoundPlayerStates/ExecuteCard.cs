namespace TradingCardGameStateMachine.RoundPlayerStates
{
	public class ExecuteCard : RoundPlayerState
	{
		public override void Update(Player active, Player other, Round round)
		{
			active.SelectedCard.CastAction(active, other, active.SelectedCard);
			round.State = new RoundDone();
		}
	}
}