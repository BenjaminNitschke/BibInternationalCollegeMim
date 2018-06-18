using System;
using System.Collections.Generic;

namespace TradingCardGameStateMachine
{
	public class Game
	{
		public Game(Action<GameState> onStateChange = null)
		{
			OnStateChange = onStateChange;
			Players = new List<Player> { new Player("Player 1"), new Player("Player 2") };
			GoToNextState(new ChooseStartPlayer());
		}

		public GameState State { get; private set; }
		public List<Player> Players { get; }
		public Player StartPlayer { get; set; }
		public void Tick() => State.Update(this);
		public void GoToNextState(GameState state)
		{
			State = state;
			OnStateChange?.Invoke(state);
		}
		public Action<GameState> OnStateChange { get; set; }
	}
}