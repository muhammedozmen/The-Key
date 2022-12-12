using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private float doorDistance;
    public LayerMask doorLayerMask;

    public Doors doors;

    void Start()
    {
        
    }

    
    void Update()
    {
        DoorInteraction();  
    }

    private void DoorInteraction()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit, doorDistance, doorLayerMask))
        {
            doors.canInteract = true;
        }
        else
        {
            doors.canInteract = false;
        }
    }
}
