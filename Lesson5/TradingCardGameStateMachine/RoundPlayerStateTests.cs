using System;
using NUnit.Framework;

namespace TradingCardGameStateMachine
{
	public class RoundPlayerStateTests
	{
		[Test]
		public void GoThroughRoundPlayerStates()
		{
			var dummyGame = new Game();
			var round = new Round(new Player("A"), new Player("B"));
			Assert.That(round.State, Is.InstanceOf<InitializeRound>());
			round.Tick(dummyGame);
			Assert.That(round.State, Is.InstanceOf<SelectCard>());
			round.Tick(dummyGame);
			Assert.That(round.State, Is.InstanceOf<ExecuteCard>());
			round.Tick(dummyGame);
			Assert.That(round.State, Is.InstanceOf<RoundDone>());
		}
	}

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

	public abstract class RoundPlayerState
	{
		public abstract void Update(Player activePlayer, Player otherPlayer, Round round);
	}

	public class InitializeRound : RoundPlayerState {
		public override void Update(Player activePlayer, Player otherPlayer, Round round)
		{
			round.State = new SelectCard();
		}
	}
	public class SelectCard : RoundPlayerState {
		public override void Update(Player activePlayer, Player otherPlayer, Round round)
		{
			//Could be asking player
			activePlayer.SelectedCard =
				activePlayer.Cards[new Random().Next(activePlayer.Cards.Count)];
			round.State = new ExecuteCard();
		}
	}
	public class ExecuteCard : RoundPlayerState {
		public override void Update(Player activePlayer, Player otherPlayer, Round round)
		{
			activePlayer.SelectedCard.CastAction(activePlayer, otherPlayer, activePlayer.SelectedCard);
			round.State = new RoundDone();
		}
	}
	public class RoundDone : RoundPlayerState
	{
		public override void Update(Player activePlayer, Player otherPlayer, Round round) {}
	}
}
