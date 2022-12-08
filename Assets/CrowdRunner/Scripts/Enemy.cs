using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State
    {
        Idle,Running
    }

    [SerializeField] float searchRadius;
    [SerializeField] float moveSpeed;

    private State state;
    private Transform targetRunner;

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,searchRadius);
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        switch (state)
        {
            case State.Idle:
                SearchForTarget();
                break;
            case State.Running:
                RunTowardsTarget();
                break;
        }
    }

    private void RunTowardsTarget()
    {
        if (targetRunner==null)
        {
            Debug.Log($"target is null");
            return;
        }

        transform.position=Vector3.MoveTowards(transform.position,targetRunner.position,Time.deltaTime*moveSpeed);

        if (Vector3.Distance(transform.position,targetRunner.position)<1f)        
        {
            Debug.Log($"destory null");
            Destroy(targetRunner.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"do not destory null");
        }
    }
    private void StartRunningTowardToTarget()
    {
        state=State.Running;
        GetComponent<Animator>().Play("Run");
    }
    private void SearchForTarget()
    {
        Collider[] detectedColliders=Physics.OverlapSphere(transform.position,searchRadius);

        for (int i = 0; i < detectedColliders.Length; i++)
        {
            if (detectedColliders[i].TryGetComponent(out Runner runner))
            {
                if(runner.IsTarget())
                    continue;

                runner.SetTarget();

                targetRunner=runner.transform;

                StartRunningTowardToTarget();
            }
        }
    }
}
