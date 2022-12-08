using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] int amount;
    [SerializeField] float radius;
    [SerializeField] float goldenAngle;
    [SerializeField] Transform enemyParent;

    private void Start()
    {
        GenerateEnemys();
    }
    void GenerateEnemys()
    {
        for (int i = 0; i <amount; i++)
        {
            Vector3 enemyLocalPosition=GetRunnerLocalPosition(i);
            Vector3 worldPosition=enemyParent.TransformPoint(enemyLocalPosition);
            Instantiate(enemyPrefab,worldPosition,Quaternion.identity,enemyParent);
        }
    }

    Vector3 GetRunnerLocalPosition(int runnerIndex)
    {
        float x=radius * Mathf.Sqrt(runnerIndex) * Mathf.Cos(Mathf.Deg2Rad * runnerIndex * goldenAngle);
        float z=radius * Mathf.Sqrt(runnerIndex) * Mathf.Sin(Mathf.Deg2Rad * runnerIndex * goldenAngle);

        return new Vector3(x,0,z);
    }

}
