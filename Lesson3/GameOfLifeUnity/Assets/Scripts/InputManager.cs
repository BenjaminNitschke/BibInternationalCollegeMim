using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class InputManager : MonoBehaviour
{
    private MenuStateMachine menuStateMachine;

    public static InputManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }

        menuStateMachine = MenuStateMachine.Instance;
    }

    public void MainMenu()
    {
        menuStateMachine.ChangeState(States.MainMenu);
        SceneManager.LoadScene(0);
    }

    public void PlayNewGame()
    {
        menuStateMachine.ChangeState(States.Start);
        SceneManager.LoadScene(1);
        menuStateMachine.ChangeState(States.Game);
    }

    public void LoadGame()
    {
        // menuStateMachine.ChangeState(States.Load);
        // SceneManager.LoadScene(2);
    }

    public void Options()
    {
        menuStateMachine.ChangeState(States.Options);
        SceneManager.LoadScene(2);
    }

    public void Graphics()
    {
        menuStateMachine.ChangeState(States.Graphics);
        SceneManager.LoadScene(3);
    }

    public void Sound()
    {
        // menuStateMachine.ChangeState(States.Sound);
        // SceneManager.LoadScene(3);
    }

    public void Controls()
    {
        // menuStateMachine.ChangeState(States.Controls);
        // SceneManager.LoadScene(3);
    }

    public void Credits()
    {
        // menuStateMachine.ChangeState(States.Credits);
        // SceneManager.LoadScene(3);
    }

    public void EndGame()
    {
        menuStateMachine.ChangeState(States.GameOver);
        menuStateMachine.ChangeState(States.MainMenu);
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        menuStateMachine.ChangeState(States.Exit);
        EditorApplication.isPlaying = false;
    }
}
