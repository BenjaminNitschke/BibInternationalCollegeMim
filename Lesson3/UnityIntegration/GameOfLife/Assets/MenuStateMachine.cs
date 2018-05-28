using System;
using UnityEngine;

//Different ways to work with state machines:
// 1. if/else mess
// 2. dictionary with enums
// 3. dictionary or lists with actions
// 4. class based (used here via MenuState classes)
public class MenuStateMachine : MonoBehaviour
{
	void Start()
	{
		states = this;
		currentState = new MainMenuState();
	}

	void Update()
	{
		currentState.Update();
	}

	public static MenuStateMachine states;
	public MenuState currentState = new MainMenuState();

	public void ChangeState(string newState)
	{
		if (newState == "MainMenu")
			currentState = new MainMenuState();
		else if (newState == "Start" || newState == "Load")
			currentState = new PlayGameState();
		else if (newState == "Options")
			currentState = new OptionsState();
		else if (newState == "Credits")
			currentState = new CreditsState();
		else if (newState == "Exit")
			currentState = new ExitState();
		else
			throw new NotSupportedException("State change to " + newState + " is not supported yet!");
		currentState.Start();
	}
}