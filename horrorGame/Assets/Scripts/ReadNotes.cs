using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReadNotes : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject noteUI;
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject inventory;

    [SerializeField] private GameObject pickUpText;

    [SerializeField] private AudioSource pickUpSound;

    [SerializeField] private TextMeshProUGUI code1;
    [SerializeField] private TextMeshProUGUI code2;
    [SerializeField] private TextMeshProUGUI code3;
    [SerializeField] private TextMeshProUGUI code4;
    [SerializeField] private Doors SecretDoor;

    private bool inReach;

    void Start()
    {
        noteUI.SetActive(false);
        hud.SetActive(true);
        inventory.SetActive(true);
        pickUpText.SetActive(false);

        inReach = false;

        code1.text = SecretDoor.number1.ToString();
        code2.text = SecretDoor.number2.ToString();
        code3.text = SecretDoor.number3.ToString();
        code4.text = SecretDoor.number4.ToString();
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
            cam.GetComponent<FirstPersonLook>().enabled = false;
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
        cam.GetComponent<FirstPersonLook>().enabled = true;
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
