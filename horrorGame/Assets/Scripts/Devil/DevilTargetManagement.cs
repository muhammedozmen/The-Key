using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DevilTargetManagement : MonoBehaviour
{
    [SerializeField] private DevilAI devilAI;
    [SerializeField] private GameObject devilSpawnPoint;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            devilAI.target = devilSpawnPoint;
            devilAI.isTargetable = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            devilAI.isTargetable = true;
        }
    }
}
