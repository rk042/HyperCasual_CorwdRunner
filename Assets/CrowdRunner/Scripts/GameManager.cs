using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameState
{
    Menu,Game,LevelComplete,GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameState gameState;
    public Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        if (instance!=null)
        {
            Destroy(instance.gameObject);
        }
        else
        {        
            instance=this;
        }

    }
    
    public void SetGameState(GameState gameState)
    {
        this.gameState=gameState;
        OnGameStateChanged?.Invoke(gameState);
    }

    public bool IsGameState()
    {
        return gameState==GameState.Game;
    }
}
