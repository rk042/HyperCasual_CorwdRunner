using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header(" Elementes ")]
    [SerializeField] PlayerAnimator playerAnimator;
    [SerializeField] Transform runnerParent;
    [SerializeField] GameObject runnerPrefab;

    [Header(" Settings ")]
    [SerializeField] float goldenAngle;
    [SerializeField] float radius;


    // Update is called once per frame
    void Update()
    {
        PlaceRunners();
    }

    void PlaceRunners()
    {
        for (int i = 0; i < runnerParent.childCount; i++)
        {
            var childLocalPosition=GetRunnerLocalPosition(i);
            runnerParent.GetChild(i).localPosition=childLocalPosition;
        }
    }

    Vector3 GetRunnerLocalPosition(int runnerIndex)
    {
        float x=radius * Mathf.Sqrt(runnerIndex) * Mathf.Cos(Mathf.Deg2Rad * runnerIndex * goldenAngle);
        float z=radius * Mathf.Sqrt(runnerIndex) * Mathf.Sin(Mathf.Deg2Rad * runnerIndex * goldenAngle);

        return new Vector3(x,0,z);
    }

    public float GetCrowdRadius()
    {
        return radius * Mathf.Sqrt(runnerParent.childCount);
    }

    public void ApplyBonus(BonusType bonusType, int bonusAmount)
    {
        switch (bonusType)
        {
            case BonusType.Addition:
                AddRunners(bonusAmount);
                break;
            case BonusType.Difference:
                RemoveRunners(bonusAmount);
                break;
            case BonusType.Division:
                var bonusAmountDivision=runnerParent.childCount-(runnerParent.childCount/bonusAmount);
                RemoveRunners(bonusAmountDivision);
                break;
            case BonusType.Product:
                int bonusAmountProduct = (bonusAmount * runnerParent.childCount) - runnerParent.childCount;
                AddRunners(bonusAmountProduct);
                break;
        }
    }

    private void RemoveRunners(int bonusAmount)
    {
        if (bonusAmount>runnerParent.childCount)
        {
            bonusAmount=runnerParent.childCount;
            GetComponent<PlayerController>().HideMessageBox();
        }

        for (int i = 0; i < bonusAmount; i++)
        {
            Destroy(runnerParent.GetChild(i).gameObject);
        }
    }

    private void AddRunners(int bonusAmount)
    {
        for (int i = 0; i < bonusAmount; i++)
        {
            Instantiate(runnerPrefab,runnerParent);
        }

        playerAnimator.Run();
    }
}
