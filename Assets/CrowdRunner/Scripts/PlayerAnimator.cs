using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Transform runnerParent;

    public void Idle()
    {
        for (int i = 0; i < runnerParent.childCount; i++)
        {
            var runner=runnerParent.GetChild(i);
            var animator=runner.GetComponent<Animator>();
            animator.Play("Idle");
        }
    }

    public void Run()
    {
        for (int i = 0; i < runnerParent.childCount; i++)
        {
            var runner=runnerParent.GetChild(i);
            var animator=runner.GetComponent<Animator>();
            animator.Play("Run");
        }
    }
}