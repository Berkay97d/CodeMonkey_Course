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
                }
                break;
            case GameState.CountdownToStart:
                countdownToStartTime -= Time.deltaTime;
                if (countdownToStartTime <= 0f)
                {
                    state = GameState.Playing;
                }
                break;
            case GameState.Playing:
                gameplayTime -= Time.deltaTime;
                if (gameplayTime <= 0f)
                {
                    state = GameState.Over;
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
}
