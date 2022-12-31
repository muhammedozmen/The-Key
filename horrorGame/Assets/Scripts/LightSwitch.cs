using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private GameObject lightsText;

    [SerializeField] private GameObject lightObject;
    [SerializeField] private GameObject halo;
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject smoke;

    //[SerializeField] private AudioSource lightOn;
    //[SerializeField] private AudioSource lightOff;

    private bool isLightOn;
    private bool inReach;
    
    void Start()
    {
        inReach = false;
        isLightOn = false;
    }

    
    void Update()
    {
        if(isLightOn == true && inReach == true && Input.GetKeyDown(KeyCode.E))
        {
            lightObject.SetActive(false);
            halo.SetActive(false);
            fire.SetActive(false);
            smoke.SetActive(false);
            //lightOn.Play();
            isLightOn=false;
        }
        else if(isLightOn == false && inReach == true && Input.GetKeyDown(KeyCode.E))
        {
            lightObject.SetActive(true);
            halo.SetActive(true);
            fire.SetActive(true);
            smoke.SetActive(true);
            //lightOff.Play();    
            isLightOn = true;
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
        }
    }


}
