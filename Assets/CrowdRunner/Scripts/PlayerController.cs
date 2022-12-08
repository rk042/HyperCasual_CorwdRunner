using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] CrowdSystem crowdSystem;
    [SerializeField] PlayerAnimator playerAnimator;

    [Header(" Settings ")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float roadWidth;

    [Header(" Control ")]
    [SerializeField] private float slideSpeed;
    [SerializeField] private GameObject messageBox;
    [SerializeField] private bool canMove;

    Vector3 clickScreenPosition;
    Vector3 clickPlayerPosition;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        instance=this;
    }
    private void OnEnable()
    {
        GameManager.instance.OnGameStateChanged+=OnGameStateChanged;
    }

    private void OnDisable()
    {
        GameManager.instance.OnGameStateChanged-=OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState obj)
    {
        if (obj==GameState.Game)
        {
            StartMoving();
        }
        else if(obj==GameState.GameOver || obj==GameState.LevelComplete)
        {
            StopMoving();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {            
            MoveForward();
            ManageControl();
        }
    }
    void StartMoving()
    {
        canMove=this;
        playerAnimator.Run();
    }
    void StopMoving()
    {
        canMove=false;
        playerAnimator.Idle();
    }

    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickScreenPosition=Input.mousePosition;
            clickPlayerPosition=transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            float xScreenDiffernce=Input.mousePosition.x-clickScreenPosition.x;
            xScreenDiffernce= xScreenDiffernce/Screen.width;
            xScreenDiffernce*=slideSpeed;
            var position=transform.position;
            position.x=clickPlayerPosition.x+xScreenDiffernce;
            position.x=Mathf.Clamp(position.x,-roadWidth+crowdSystem.GetCrowdRadius(),roadWidth - crowdSystem.GetCrowdRadius());
            transform.position=position;
        }
    }

    void MoveForward()
    {
        transform.position+=Vector3.forward*Time.deltaTime*moveSpeed;
    }

    public void HideMessageBox()
    {
        messageBox.SetActive(false);
    }
}
