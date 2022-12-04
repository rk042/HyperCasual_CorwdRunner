using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{

    [SerializeField] Chunk[] chunkPrefabArray;
    [SerializeField] Chunk[] levelChunksArray;

    // Start is called before the first frame update
    void Start()
    {
        CreateOrderedLevel();
    }

    private void CreateOrderedLevel()
    {
        Vector3 chunkPosition = Vector3.zero;
        for (int i = 0; i < levelChunksArray.Length; i++)
        {
            var chankToCreate = levelChunksArray[i];
            if (i > 0)
            {
                chunkPosition.z += chankToCreate.GetLength() / 2;
            }
            var chunk = Instantiate(chankToCreate, chunkPosition, Quaternion.identity, transform);
            chunkPosition.z += chunk.GetLength() / 2;
        }
    }

    void GenerateRandomChunks()
    {
        Vector3 chunkPosition = Vector3.zero;
        for (int i = 0; i < chunkPrefabArray.Length; i++)
        {
            var chankToCreate = chunkPrefabArray[Random.Range(0, levelChunksArray.Length)];
            if (i > 0)
            {
                chunkPosition.z += chankToCreate.GetLength() / 2;
            }
            var chunk = Instantiate(chankToCreate, chunkPosition, Quaternion.identity, transform);
            chunkPosition.z += chunk.GetLength() / 2;
        }
    }
}
