using TradingCardGameStateMachine.RoundPlayerStates;

namespace TradingCardGameStateMachine.GameStates
{
	public class Playing : GameState
	{
		public override void Update(Game game)
		{
			ExecutePlayerStates(game.StartPlayer, game.OtherPlayer, game);
			ExecutePlayerStates(game.OtherPlayer, game.StartPlayer, game);
			game.RoundNumber++;
			if (game.StartPlayer.HP <= 0 || game.OtherPlayer.HP <= 0 || game.StartPlayer.Mana < 0)
				game.GoToNextState(new GameOver());
		}

		public void ExecutePlayerStates(Player current, Player other, Game game)
		{
			var round = new Round(current, other);
			while (!(round.State is RoundDone))
				round.Tick(game);
		}
	}
}