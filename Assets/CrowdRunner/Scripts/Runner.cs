using System;
using UnityEngine;

public class Runner : MonoBehaviour
{
    [SerializeField] bool isTarget;

    internal bool IsTarget()
    {
        return isTarget;
    }

    internal void SetTarget()
    {
        isTarget=true;
    }
}