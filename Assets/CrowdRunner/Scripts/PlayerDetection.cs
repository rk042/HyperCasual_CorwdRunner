using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] CrowdSystem crowdSystem;

    void Update()
    {
        DetectDoors();
    }

    void DetectDoors()
    {
        Collider[] detectedColliders=Physics.OverlapSphere(transform.position,1);

        for (int i = 0; i < detectedColliders.Length; i++)
        {
            if (detectedColliders[i].TryGetComponent(out Doors doors))
            {

                int bonusAmount=doors.GetBonusAmount(transform.position.x);
                BonusType bonusType=doors.GetBonusType(transform.position.x);
                doors.Disable();
                crowdSystem.ApplyBonus(bonusType,bonusAmount);
            }
            else if(detectedColliders[i].tag=="finish")
            {
                //Game Over You Won!
                Debug.Log($"Game Over You Won !");
                SceneManager.LoadScene(0);
            }
        }
        
    }
}
