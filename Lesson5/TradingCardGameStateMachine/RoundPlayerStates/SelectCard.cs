using System;

namespace TradingCardGameStateMachine.RoundPlayerStates
{
	public class SelectCard : RoundPlayerState
	{
		public override void Update(Player active, Player other, Round round)
		{
			//Could be asking player
			active.SelectedCard =
				active.Cards[new Random().Next(active.Cards.Count)];
			round.State = new ExecuteCard();
		}
	}
}