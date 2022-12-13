using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    [SerializeField] private GameObject keyOnGround;
    [SerializeField] private GameObject keyOnInventory;
    [SerializeField] private GameObject pickUpText;
    [SerializeField] private AudioSource pickUpSound;

    [SerializeField] private bool inReach;

    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        keyOnInventory.SetActive(false);
    }

    
    void Update()
    {
        if(inReach && Input.GetKeyDown(KeyCode.E))
        {
            keyOnGround.SetActive(false);
            pickUpSound.Play();
            keyOnInventory.SetActive(true);
            pickUpText.SetActive(false);
        }
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
