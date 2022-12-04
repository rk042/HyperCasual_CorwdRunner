using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] Vector3 chunkSize;


    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color=Color.blue;
        Gizmos.DrawWireCube(transform.position,chunkSize);
    }

    public float GetLength()
    {
        return chunkSize.z;
    }
}