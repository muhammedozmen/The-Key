using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private DevilAI devilAI;

    [SerializeField] private GameObject lightsText;
    [SerializeField] private GameObject notAllowedText;
    [SerializeField] private GameObject notAllowedText2;

    [SerializeField] private Light lightObject;
    [SerializeField] private GameObject halo;
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject smoke;

    [SerializeField] LightFlicker lightFlicker;

    [SerializeField] private AudioClip lightOn;
    [SerializeField] private AudioSource AudioSource;

    private bool isLightOn;
    private bool inReach;
    
    void Start()
    {
        inReach = false;
        isLightOn = false;
    }

    
    void LateUpdate()
    {  
            if (isLightOn == true && inReach == true && Input.GetKeyDown(KeyCode.E) && lightFlicker.isDevilTriggered == false && devilAI.rageLevel <= 5)
            {
                lightObject.enabled = false;
                halo.SetActive(false);
                fire.SetActive(false);
                smoke.SetActive(false);
                AudioSource.Pause();
                isLightOn = false;
            }
            else if (isLightOn == false && inReach == true && Input.GetKeyDown(KeyCode.E) && lightFlicker.isDevilTriggered == false && devilAI.rageLevel <= 5)
            {
                lightObject.enabled = true;
                halo.SetActive(true);
                fire.SetActive(true);
                smoke.SetActive(true);
                AudioSource.PlayOneShot(lightOn);
                AudioSource.Play();
                isLightOn = true;
            }
            else if (inReach == true && Input.GetKeyDown(KeyCode.E) && lightFlicker.isDevilTriggered == true)
            {
                lightsText.SetActive(false);
                notAllowedText.SetActive(true);
            }
            else if (inReach == true && Input.GetKeyDown(KeyCode.E) && devilAI.rageLevel > 5)
            {
                lightsText.SetActive(false);
                notAllowedText2.SetActive(true);
            }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
            lightsText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            lightsText.SetActive(false);
            notAllowedText.SetActive(false);
            notAllowedText2.SetActive(false);
        }
    }


}
