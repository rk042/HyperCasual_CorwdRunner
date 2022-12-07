using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject menuObject;
    [SerializeField] Slider progressBar;
    [SerializeField] GameObject gamePanel;
    [SerializeField] TextMeshProUGUI txtLevel;
    
    private void Start()
    {
        progressBar.value=0;
        gamePanel.SetActive(false);
        txtLevel.text=$"Level {ChunkManager.instance.GetLevel()+1}";
    }
   
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

    private void OnDisable()
    {
        GameManager.instance.OnGameStateChanged-=OnGameStateChanged;
    }
    
    private void Update()
    {
        UpdateProgressBar();
    }
    public void btnPlay()
    {
        GameManager.instance.SetGameState(GameState.Game);
        gamePanel.SetActive(true);
    }

    public void UpdateProgressBar()
    {

        if (!GameManager.instance.IsGameState())
        {
            return ;
        }

        float progress=PlayerController.instance.transform.position.z/ChunkManager.instance.GetFinishZ();

        progressBar.value=progress;
    }
}
