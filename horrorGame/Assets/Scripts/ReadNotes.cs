using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNotes : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject noteUI;
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject inventory;

    [SerializeField] private GameObject pickUpText;

    [SerializeField] private AudioSource pickUpSound;

    private bool inReach;

    void Start()
    {
        noteUI.SetActive(false);
        hud.SetActive(true);
        inventory.SetActive(true);
        pickUpText.SetActive(false);

        inReach = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inReach)
        {
            noteUI.SetActive(true);
            pickUpSound.Play();
            hud.SetActive(false);
            inventory.SetActive(false);
            player.GetComponent<FirstPersonMovement>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            pickUpText.SetActive(false);
        }
    }

    public void ExitButton()
    {
        Cursor.lockState = CursorLockMode.Locked;
        noteUI.SetActive(false);
        hud.SetActive(true);
        inventory.SetActive(true);
        player.GetComponent<FirstPersonMovement>().enabled = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }
}
