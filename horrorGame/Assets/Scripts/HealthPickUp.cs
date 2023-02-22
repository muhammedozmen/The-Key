using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] private GameObject pickUpObject;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pickUpText;
    [SerializeField] private GameObject cannotPickUpText;
    [SerializeField] private float addHealth = 25f;
    [SerializeField] private float currentHealth;

    [SerializeField] private AudioSource healthPickUpSound;

    [SerializeField] private GameObject screenFX;

    private bool inReach;


    private void Start()
    {
        currentHealth = player.GetComponent<PlayerHealth>().health;
        cannotPickUpText.SetActive(false);
        pickUpText.SetActive(false);

        screenFX.SetActive(false);

        inReach = false;
    }

    private void Update()
    {
        if(inReach && Input.GetKeyDown(KeyCode.E) && player.GetComponent<PlayerHealth>().health < 100)
        {
            inReach = false;
            healthPickUpSound.Play();
            player.GetComponent<PlayerHealth>().health += addHealth;
            screenFX.SetActive(true);
            pickUpObject.GetComponent<BoxCollider>().enabled = false;
            pickUpObject.GetComponent<MeshRenderer>().enabled = false;
            pickUpText.SetActive(false);
            StartCoroutine(TurnScreenFXOFF());
        }
        else if(inReach && Input.GetKeyDown(KeyCode.E) && player.GetComponent<PlayerHealth>().health == 100)
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
            cannotPickUpText.SetActive(false);
        }
    }
}
