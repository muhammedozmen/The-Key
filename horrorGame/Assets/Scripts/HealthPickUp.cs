using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] private GameObject pickUpObject;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pickUpText;
    [SerializeField] private GameObject cannotUseText;
    [SerializeField] private GameObject screenFX;

    [SerializeField] private float addHealth = 25f;

    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] private AudioSource healthUseSound;
    [SerializeField] private AudioSource potionPickUp;

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
        Interact();
        HealthUse();

    }

    private void Interact()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            playerHealth.healthAmount++;
            inReach = false;
            pickUpObject.GetComponent<BoxCollider>().enabled = false;
            pickUpObject.GetComponent<MeshRenderer>().enabled = false;
            pickUpText.SetActive(false);
            potionPickUp.Play();
        }
    }

    private void HealthUse()
    {
        if (playerHealth.healthAmount > 0 && Input.GetKeyDown(KeyCode.C) && player.GetComponent<PlayerHealth>().health < 100)
        {
            playerHealth.isJustUsed = true;
            player.GetComponent<PlayerHealth>().health += addHealth;
            screenFX.SetActive(true);
            playerHealth.healthAmount--;
            healthUseSound.Play();
            StartCoroutine(TurnScreenFXOFF());
        }
        else if (playerHealth.healthAmount > 0 && Input.GetKeyDown(KeyCode.C) && player.GetComponent<PlayerHealth>().health == 100)
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
        playerHealth.isJustUsed = false;
    }

    IEnumerator CloseCannotUseText()
    {
        yield return new WaitForSeconds(3.25f);
        cannotUseText.SetActive(false);
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
