using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateMachine
{
    public States currentState { get; private set; }

    private Dictionary<States, List<States>> availableStates;

    private static MenuStateMachine instance;

    public static MenuStateMachine Instance
    {
        get
        {
            if (instance == null) instance = new MenuStateMachine(States.MainMenu);
            return instance;
        }
    }


    private MenuStateMachine(States currentState)
    {
        this.currentState = currentState;
        availableStates = new Dictionary<States, List<States>>()
        {
            { States.Loading, new List<States>() {States.MainMenu} },
            { States.MainMenu, new List<States>() {States.MainMenu, States.Start, States.Load, States.Options, States.Credits, States.Exit} },
            { States.Exit, new List<States>() },
            { States.Start, new List<States>() { States.MainMenu, States.Game } },
            { States.Load, new List<States>() { States.MainMenu, States.Game } },
            { States.Options, new List<States>() { States.MainMenu, States.Graphics, States.Sound, States.Credits, States.Controls } },
            { States.Credits, new List<States>() { States.Options } },
            { States.Graphics, new List<States>() { States.Options } },
            { States.Sound, new List<States>() { States.Options } },
            { States.Game, new List<States>() { States.GameOver } },
            { States.GameOver, new List<States>() { States.MainMenu } }
        };
    }

    public void ChangeState(States newState)
    {
        if (availableStates[currentState].Contains(newState))
        {
            currentState = newState;
            return;
        }

        throw new System.NotSupportedException(string.Format("{0} is not avalable to you in {1}", newState, currentState));
    }
}
