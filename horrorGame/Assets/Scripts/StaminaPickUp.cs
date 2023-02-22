using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPickUp : MonoBehaviour
{
    [SerializeField] private GameObject pickUpObject;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pickUpText;
    [SerializeField] private GameObject cannotPickUpText;
    [SerializeField] private float addStamina = 200f;
    

    [SerializeField] private AudioSource staminaPickUpSound;

    [SerializeField] private GameObject screenFX;

    private bool inReach;


    private void Start()
    {
        
        cannotPickUpText.SetActive(false);
        pickUpText.SetActive(false);

        screenFX.SetActive(false);

        inReach = false;
    }

    private void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E) && player.GetComponent<PlayerStamina>().stamina < 200)
        {
            inReach = false;
            staminaPickUpSound.Play();
            player.GetComponent<PlayerStamina>().stamina += addStamina;
            screenFX.SetActive(true);
            pickUpObject.GetComponent<BoxCollider>().enabled = false;
            pickUpObject.GetComponent<MeshRenderer>().enabled = false;
            pickUpText.SetActive(false);
            StartCoroutine(TurnScreenFXOFF());
        }
        else if (inReach && Input.GetKeyDown(KeyCode.E) && player.GetComponent<PlayerStamina>().stamina == 200)
        {
            pickUpText.SetActive(false);
            cannotPickUpText.SetActive(true);
        }
    }

    IEnumerator TurnScreenFXOFF()
    {
        yield return new WaitForSeconds(1.25f);
        screenFX.SetActive(false);
        pickUpObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
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
            cannotPickUpText.SetActive(false);
        }
    }
}
