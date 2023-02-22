using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cam;

    public float health = 100f;
    
    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;

        deathScreen.SetActive(false);
    }

    
    void Update()
    {
        if(health <= 0)
        {
            player.GetComponent<FirstPersonMovement>().enabled = false;
            cam.GetComponent<FirstPersonLook>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            deathScreen.SetActive(true);
        }

        if(health > 100)
        {
            health = 100;
        }
    }
}
