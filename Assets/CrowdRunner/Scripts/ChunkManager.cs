using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager instance;

    [SerializeField] LevelSO[] levelSOArray;

    private GameObject finishLine;
    

    private void Awake()
    {
        instance=this;
    }
    // Start is called before the first frame update
    void Start()
    {
        // CreateOrderedLevel();
        GenerateLevel();
        finishLine=GameObject.FindWithTag("finish");
    }

    private void GenerateLevel()
    {
        var currentLevel=GetLevel();
        currentLevel=currentLevel%levelSOArray.Length;
        LevelSO level=levelSOArray[currentLevel];

        CreateOrderedLevel(level);
    }

    private void CreateOrderedLevel(LevelSO levelSO)
    {
        Vector3 chunkPosition = Vector3.zero;
        for (int i = 0; i < levelSO.chunkArray.Length; i++)
        {
            var chankToCreate = levelSO.chunkArray[i];
            if (i > 0)
            {
                chunkPosition.z += chankToCreate.GetLength() / 2;
            }
            var chunk = Instantiate(chankToCreate, chunkPosition, Quaternion.identity, transform);
            chunkPosition.z += chunk.GetLength() / 2;
        }
    }

    public float GetFinishZ()
    {
        return finishLine.transform.position.z;
    }

    public int GetLevel()
    {
        return PlayerPrefs.GetInt("Level",0);
    }
}
