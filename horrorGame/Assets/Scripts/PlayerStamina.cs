using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private GameObject player;  

    public float stamina = 0f;



    void Update()
    {
        if (stamina <= 0)
        {
            player.GetComponent<FirstPersonMovement>().canRun = false;
        }

        if(stamina > 0 && stamina <= 200)
        {
            player.GetComponent<FirstPersonMovement>().canRun = true;
            stamina -= Time.deltaTime;
        }

        if (stamina > 200)
        {
            stamina = 200;
        }
    }
}
