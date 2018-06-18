using System;
using System.Collections.Generic;

namespace TradingCardGameStateMachine
{
	public class Game
	{
		public Game(Action<GameState, RoundPlayerState, Player> onStateChange = null)
		{
			OnStateChange = onStateChange;
			Players = new List<Player> { new Player("Player 1"), new Player("Player 2") };
			GoToNextState(new ChooseStartPlayer());
		}

		public Action<GameState, RoundPlayerState, Player> OnStateChange { get; set; }
		public GameState State { get; private set; }
		public List<Player> Players { get; }
		public Player StartPlayer { get; set; }
		public void Tick() => State.Update(this);

		public void GoToNextState(GameState state)
		{
			State = state;
			NotifyStateChange(state);
		}
		public void NotifyStateChange(GameState state, RoundPlayerState roundState = null, Player roundCurrentPlayer = null)
		{
			OnStateChange?.Invoke(state, roundState, roundCurrentPlayer);
		}
		public Player OtherPlayer
			=> Players[Players[0] == StartPlayer ? 1 : 0];
		public int RoundNumber { get; set; }
	}
}