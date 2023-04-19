using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    [SerializeField] private LightFlicker lightFlicker;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Devil")
        { 
            lightFlicker.isDevilTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Devil")
        {
            lightFlicker.isDevilTriggered = false;
            lightFlicker.lightObject.enabled = true;
            lightFlicker.lightObject2.enabled = true;
            lightFlicker.halo.SetActive(true);
            lightFlicker.fire.SetActive(true);
            lightFlicker.smoke.SetActive(true);
        }
    }
}
