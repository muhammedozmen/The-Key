using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StaminaPickUp : MonoBehaviour
{
    [SerializeField] private GameObject pickUpObject;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pickUpText;
    [SerializeField] private GameObject cannotUseText;
    [SerializeField] private float addStamina = 100f;
    [SerializeField] private PlayerStamina playerStamina;

    


    [SerializeField] private AudioSource staminaUseSound;

    [SerializeField] private GameObject screenFX;

    private bool inReach;


    

    private void Start()
    {
        
        cannotUseText.SetActive(false);
        pickUpText.SetActive(false);
        screenFX.SetActive(false);
        inReach = false;
    }

    private void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            playerStamina.staminaAmount++;
            inReach = false;
            pickUpObject.GetComponent<BoxCollider>().enabled = false;
            pickUpObject.GetComponent<MeshRenderer>().enabled = false;
            pickUpText.SetActive(false);
        }



        if (playerStamina.staminaAmount > 0 && Input.GetKeyDown(KeyCode.V) && player.GetComponent<PlayerStamina>().stamina < 100)
        {
            playerStamina.isJustUsed = true;
            player.GetComponent<PlayerStamina>().stamina += addStamina;
            screenFX.SetActive(true);
            playerStamina.staminaAmount--;
            staminaUseSound.Play();
            StartCoroutine(TurnScreenFXOFF());
        }
        else if (playerStamina.staminaAmount > 0 && Input.GetKeyDown(KeyCode.V) && player.GetComponent<PlayerStamina>().stamina == 100)
        {
            cannotUseText.SetActive(true);
            StartCoroutine(CloseCannotUseText());
        }
        
    }

    IEnumerator TurnScreenFXOFF()
    {
        yield return new WaitForSeconds(1.25f);
        screenFX.SetActive(false);
        pickUpObject.SetActive(false);
        playerStamina.isJustUsed = false;
    }

    IEnumerator CloseCannotUseText()
    {
        yield return new WaitForSeconds(3.25f);
        cannotUseText.SetActive(false);
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
        }
    }
}
