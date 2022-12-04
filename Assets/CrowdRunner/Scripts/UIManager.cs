using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject menuObject;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        GameManager.instance.OnGameStateChanged+=OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState obj)
    {
        if (obj==GameState.Game)
        {
            menuObject.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    private void OnDisable()
    {
        GameManager.instance.OnGameStateChanged-=OnGameStateChanged;
    }
    public void btnPlay()
    {
        GameManager.instance.SetGameState(GameState.Game);
    }
}
