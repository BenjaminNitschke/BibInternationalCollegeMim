using System;
using NUnit.Framework;
using TradingCardGameStateMachine.GameStates;

namespace TradingCardGameStateMachine
{
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("State Machine Trading Card Game");
			var game = new Game((newState, newRoundState, currentPlayer) =>
				Console.WriteLine("Changing game state to: " + newState.GetType().Name + " " +
					(newRoundState?.GetType().Name ?? "") + " " + currentPlayer));
			game.Tick();
			while (game.State is Playing)
				game.Tick();
				//TODO: ask user for select card input
			game.Tick();
		}
	}
}
