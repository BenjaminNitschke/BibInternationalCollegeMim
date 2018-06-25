using TradingCardGameStateMachine.RoundPlayerStates;

namespace TradingCardGameStateMachine
{
	public class Round
	{
		public Round(Player activePlayer, Player otherPlayer)
		{
			this.activePlayer = activePlayer;
			this.otherPlayer = otherPlayer;
			State = new InitializeRound();
		}

		private readonly Player activePlayer;
		private readonly Player otherPlayer;
		public RoundPlayerState State;

		public void Tick(Game game)
		{
			if (State is InitializeRound)
				game.NotifyStateChange(game.State, State, activePlayer);
			State.Update(activePlayer, otherPlayer, this);
			game.NotifyStateChange(game.State, State, activePlayer);
		}
	}
}