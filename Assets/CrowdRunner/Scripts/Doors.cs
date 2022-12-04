using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public enum BonusType
{
    Addition, Difference, Product, Division
}

public class Doors : MonoBehaviour
{

    [SerializeField] SpriteRenderer rightDoorRenderer;
    [SerializeField] TextMeshPro rightDoorText;
    [SerializeField] SpriteRenderer leftDoorRenderer;
    [SerializeField] TextMeshPro leftDoorText;
    [SerializeField] BonusType rightDoorBonusType;
    [SerializeField] int rightDoorBonusAmount;
    [SerializeField] BonusType leftDoorBonusType;
    [SerializeField] int leftDoorBonusAmount;
    [SerializeField] Color bonusColor;
    [SerializeField] Color penaltyColor;
    [SerializeField] new Collider collider;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        ConfigureDoor();
    }

    void ConfigureDoor()
    {
        //Configure Right Door
        switch (rightDoorBonusType)
        {
            case BonusType.Addition:
                rightDoorRenderer.color=bonusColor;
                rightDoorText.text="+" +rightDoorBonusAmount;
                break;
            case BonusType.Difference:
                rightDoorRenderer.color=penaltyColor;
                rightDoorText.text="-" +rightDoorBonusAmount;
                break;
            case BonusType.Product:
                rightDoorRenderer.color=bonusColor;
                rightDoorText.text="*" +rightDoorBonusAmount;
                break;
            case BonusType.Division:
                rightDoorRenderer.color=penaltyColor;
                rightDoorText.text="/" +rightDoorBonusAmount;
                break;
        }

        //Configure Left Door
        switch (leftDoorBonusType)
        {
            case BonusType.Addition:
                leftDoorRenderer.color=bonusColor;
                leftDoorText.text="+" +leftDoorBonusAmount;
                break;
            case BonusType.Difference:
                leftDoorRenderer.color=penaltyColor;
                leftDoorText.text="-" +leftDoorBonusAmount;
                break;
            case BonusType.Product:
                leftDoorRenderer.color=bonusColor;
                leftDoorText.text="*" +leftDoorBonusAmount;
                break;
            case BonusType.Division:
                leftDoorRenderer.color=penaltyColor;
                leftDoorText.text="/" +leftDoorBonusAmount;
                break;
        }
    }

    public int GetBonusAmount(float x)
    {
        if (x>0)
        {
            return rightDoorBonusAmount;
        }
        else 
        {
            return leftDoorBonusAmount;
        }
    }

    public BonusType GetBonusType(float x)
    {
        if (x>0)
        {
            return rightDoorBonusType;
        }
        else 
        {
            return leftDoorBonusType;
        }
    }

    public void Disable()
    {
        collider.enabled=false;
    }
}
