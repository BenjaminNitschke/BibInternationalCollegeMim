using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateMachine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	MenuState currentState = MenuState.MainMenu;
	
	public void ChangeState(string newState)
	{
		MenuState state = (MenuState)Enum.Parse(typeof(MenuState), newState);
		if (currentState == MenuState.MainMenu)
		{
			if (state == MenuState.Start || state == MenuState.Load || state == MenuState.Options ||
					state == MenuState.Credits || state == MenuState.Exit)
				currentState = MenuState.Start;
			else
				throw new NotSupportedException("State " + state + " is not allowed in " + currentState);
		}
		//other screens
		ExecuteState(state);
	}

	private void ExecuteState(MenuState state)
	{
		switch (state)
		{
		case MenuState.MainMenu:
			//Load MainMenu scene
			break;
		case MenuState.PlayGame:
			//Load GameScene
			break;
		case MenuState.GameOver:
			//100 Ticks passed, go back to MainMenu
			break;
		case MenuState.Exit:
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
			break;
		}
	}
}