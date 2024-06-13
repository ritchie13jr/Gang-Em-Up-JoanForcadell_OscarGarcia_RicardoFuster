using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowController : MonoBehaviour
{
    public static GameFlowController instance { get { return _instance; } set { _instance = value; }}
    private static GameFlowController _instance;
    public enum GameState { PreGame, Playing, Paused, Finished }
    private GameState _gameState;
    public GameState get => _gameState;

    private void Awake() 
    {
        if (instance != null) 
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        _gameState = GameState.PreGame; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameState == GameState.Paused)
            {
                Resume();
            }
            else if (_gameState == GameState.Playing)
            {
                Pause();
            }
        }
    }

    public void YouDied() 
    {
        YouDiedMenu.instance.gameObject.SetActive(true);
    }
    public void Resume()
    {
        PauseMenu.instance.gameObject.SetActive(false);
        Time.timeScale = 1f;
        _gameState = GameState.Playing;
    }

    public void Pause()
    {
        PauseMenu.instance.gameObject.SetActive(true);
        Time.timeScale = 0f;
        _gameState = GameState.Paused;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        _gameState = GameState.PreGame;
        SceneManager.LoadScene("MainMenu");
    }
     public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        _gameState = GameState.Playing;
     
    }
    public void LoadLvl2() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
        _gameState = GameState.Finished;
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
