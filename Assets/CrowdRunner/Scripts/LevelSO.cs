using UnityEngine;

[CreateAssetMenu(fileName = "LevelSO", menuName = "SO/CreateLevel",order =0)]
public class LevelSO : ScriptableObject
{
    public Chunk[] chunkArray;
}