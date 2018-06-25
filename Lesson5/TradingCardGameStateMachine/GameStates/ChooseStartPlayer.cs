using System;

namespace TradingCardGameStateMachine.GameStates
{
	public class ChooseStartPlayer : GameState
	{
		public override void Update(Game game)
		{
			game.StartPlayer = game.Players[new Random().Next(game.Players.Count)];
			game.GoToNextState(new Playing());
		}
	}
}