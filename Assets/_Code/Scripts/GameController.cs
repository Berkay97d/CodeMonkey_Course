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

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public event EventHandler OnStateChanged;

    [SerializeField] private float waitToStartTime;
    [SerializeField] private float countdownToStartTime;
    [SerializeField] private float gameplayTime;
    
    
    private GameState state;
    

    private void Awake()
    {
        Instance = this;
        state = GameState.WaitToStart;
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
}
