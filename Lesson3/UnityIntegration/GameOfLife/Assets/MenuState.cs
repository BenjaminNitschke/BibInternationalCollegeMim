using UnityEngine.SceneManagement;

public abstract class MenuState
{
	public virtual void Start() {}
	public virtual void Update() {}
}

class MainMenuState : MenuState {
	public override void Start()
	{
		SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
	}
}

class PlayGameState : MenuState {
	public override void Start()
	{
		SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
	}
	private int tick = 0;
	public override void Update()
	{
		tick++;
		if (tick > 100)
			MenuStateMachine.states.currentState = new GameOverState();
	}
}

class GameOverState : MenuState
{
	public override void Start()
	{
		MenuStateMachine.states.currentState = new MainMenuState();
	}
}

class OptionsState : MenuState
{
	public override void Start()
	{
		SceneManager.LoadScene("OptionsScene", LoadSceneMode.Single);
	}
}

class CreditsState : MenuState
{
	public override void Start()
	{
		SceneManager.LoadScene("CreditsScene", LoadSceneMode.Single);
	}
}

class ExitState : MenuState {
	public override void Start()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}