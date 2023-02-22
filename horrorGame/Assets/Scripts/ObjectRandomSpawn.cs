using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRandomSpawn : MonoBehaviour
{
    [SerializeField] private Transform obj;
    [SerializeField] private Transform[] spawnPoint;
    
    void Start()
    {
        int indexNumber = Random.Range(0, spawnPoint.Length);
        obj.position = spawnPoint[indexNumber].position;
        obj.rotation = spawnPoint[indexNumber].rotation;
    }

    
}
