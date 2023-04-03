using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabTrigger : MonoBehaviour
{
    [SerializeField] private GameObject crabPrefab;
    [SerializeField] private GameObject spawn;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(crabPrefab, spawn.transform.position + new Vector3 (0, 1, 1), spawn.transform.rotation);
            Destroy(this);
        }
    }
}
