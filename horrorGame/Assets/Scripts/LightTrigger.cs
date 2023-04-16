using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    [SerializeField] private LightFlicker lightFlicker;
    [SerializeField] private GameObject lightObject;
    [SerializeField] private GameObject halo;
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject smoke;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Devil")
        {
            lightObject.SetActive(true);
            halo.SetActive(true);
            fire.SetActive(true);
            smoke.SetActive(true);
            lightFlicker.lightObject.enabled = true;
            lightFlicker.isDevilTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Devil")
        {
            lightObject.SetActive(false);
            halo.SetActive(false);
            fire.SetActive(false);
            smoke.SetActive(false);
            lightFlicker.lightObject.enabled = false;
            lightFlicker.isDevilTriggered = false;
        }
    }
}
