using UnityEngine;
using TMPro;

public class CrowdCounter : MonoBehaviour
{
    [SerializeField] TextMeshPro txtCrowdCounter;

    [SerializeField] Transform runnerParent;


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        txtCrowdCounter.text=runnerParent.childCount.ToString("##");

        if (runnerParent.childCount<=0)
        {
            gameObject.SetActive(false);
        }
    }
}