using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    WaitToStart,
    CountdownToStart,
    Playing,
    Over,
}

public enum GameRunnigState
{
    Paused,
    Runnig,
}

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public event EventHandler OnStateChanged;

    [SerializeField] private float waitToStartTime;
    [SerializeField] private float countdownToStartTime;
    [SerializeField] private float gameplayTimeMax;
    [SerializeField] private float gameTimeEarn;
    
    
    private float gameplayTime;
    private GameState state;
    private GameRunnigState gameRunnigState;
    

    private void Awake()
    {
        Instance = this;
        state = GameState.WaitToStart;
        gameRunnigState = GameRunnigState.Runnig;
    }

    private void Start()
    {
        GameInput.Instance.OnPause += GameInputOnPause;
        
        DeliveryCounter.Instance.OnDeliverySuccess += DeliveryCounterOnDeliverySuccess;
    }

    private void DeliveryCounterOnDeliverySuccess(object sender, EventArgs e)
    {
        gameplayTime += gameTimeEarn;
    }

    private void GameInputOnPause(object sender, EventArgs e)
    {
        if (gameRunnigState == GameRunnigState.Runnig)
        {
            PauseGame();
        }
        else
        {
            CountinueGame();
        }
    }

    private void Update()
    {
        switch (state)
        {
            case GameState.WaitToStart:
                waitToStartTime -= Time.deltaTime;
                if (waitToStartTime <= 0f)
                {
                    state = GameState.CountdownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case GameState.CountdownToStart:
                countdownToStartTime -= Time.deltaTime;
                if (countdownToStartTime <= 0f)
                {
                    state = GameState.Playing;
                    gameplayTime = gameplayTimeMax;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case GameState.Playing:
                gameplayTime -= Time.deltaTime;
                if (gameplayTime <= 0f)
                {
                    state = GameState.Over;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case GameState.Over:
                break;
        }

        Debug.Log(state);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        gameRunnigState = GameRunnigState.Paused;
    }

    private void CountinueGame()
    {
        Time.timeScale = 1;
        gameRunnigState = GameRunnigState.Runnig;
    }

    public bool IsGamePlaying()
    {
        return state == GameState.Playing;
    }

    public bool IsCountdownActive()
    {
        return state == GameState.CountdownToStart;
    }

    public float GetCountdownTimer()
    {
        return countdownToStartTime;
    }

    public bool IsGameOver()
    {
        return state == GameState.Over;
    }

    public float GetGameClockNormalized()
    {
        return 1 - (gameplayTime / gameplayTimeMax);
    }
}
