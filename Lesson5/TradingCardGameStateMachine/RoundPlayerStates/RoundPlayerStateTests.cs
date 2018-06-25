using NUnit.Framework;

namespace TradingCardGameStateMachine.RoundPlayerStates
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
}
