using System;

namespace TradingCardGameStateMachine
{
	public class Program
	{
		public static void Main()
		{
			Console.Write("State Machine Trading Card Game");
			/*
			4 Cards
			- Attack (Deals 6 dmg), 1 Mana
			- Defense (Shield blocks 5 Dmg next 2 rounds), 2 Mana
			- Magic (Revive Card), 8 Mana
			- Magic (Blocks enemy from using Attack for 3 rounds), 12 Mana

			Game Rules
			- Each player starts with 50/50 HP, 10/20 Mana, 8 random cards
			- Each round each player can play 1 card and gets 4 Mana

			States
			- Round
			- Card: ActivatedRound
			- Main States for Round Logic
			-- Handles Round Increase (could do additional things like time out player, etc.)
			-- Forwards input to Sub States
			-- Board State (which cards are active, Player list, HP, Mana, etc.)
			- Sub States for which Player is doing what
			-- Who is currently playing
			-- Executing Cards
			-- Logic for preventing cards to be played, blocking, defense, magic, etc.
			*/
			//For each round
			Console.WriteLine("Round 7: Player 1");
			Console.WriteLine("You have the following cards: Attack, Attack, Defense, Revive, Block");
			Console.WriteLine("Select card: Revive");
			Console.WriteLine("You have revived card: Defense");
			// Same for player 2, then go to next round
			Console.WriteLine("Round 7: Player 2");
			//...
		}
	}
}
