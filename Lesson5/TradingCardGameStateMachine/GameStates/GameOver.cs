using System;

namespace TradingCardGameStateMachine.GameStates
{
	public class GameOver : GameState
	{
		public override void Update(Game game)
		{
			var winnerName = game.Players[0].HP > 0 ? game.Players[0].Name : game.Players[1].Name;
			Console.WriteLine("Player " + winnerName + " won");
		}
	}
}