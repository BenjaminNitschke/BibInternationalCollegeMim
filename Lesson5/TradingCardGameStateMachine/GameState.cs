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
			//TODO: actual game
			game.GoToNextState(new GameOver());
		}
	}

	public class GameOver : GameState
	{
		public override void Update(Game game) {}
	}
}
