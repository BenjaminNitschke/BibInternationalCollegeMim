using System;

namespace TradingCardGameStateMachine
{
	public abstract class GameState
	{
		public abstract void Update(Game game);
	}

	public class ChooseStartPlayer : GameState
	{
		public override void Update(Game game)
		{
			game.StartPlayer = game.Players[new Random().Next(2)];
			game.GoToNextState(new Playing());
		}
	}

	public class Playing : GameState
	{
		public override void Update(Game game)
		{
			ExecutePlayerStates(game.StartPlayer, game.OtherPlayer, game);
			ExecutePlayerStates(game.OtherPlayer, game.StartPlayer, game);
			game.RoundNumber++;
			if (game.StartPlayer.HP <= 0 || game.OtherPlayer.HP <= 0)
				game.GoToNextState(new GameOver());
		}

		public void ExecutePlayerStates(Player current, Player other, Game game)
		{
			var round = new Round(current, other);
			while (!(round.State is RoundDone))
				round.Tick(game);
		}
	}

	public class GameOver : GameState
	{
		public override void Update(Game game)
		{
			//Show winner
		}
	}
}
