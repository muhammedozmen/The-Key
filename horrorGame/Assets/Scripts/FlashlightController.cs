using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] private float maxIntensity = 70;
    private float currentIntensity;

    [SerializeField] private Light spotLight;

    [SerializeField] private float maxBatteryHealth = 5;
    [SerializeField] private float batteryHealth;
    [SerializeField] private int batteryCount = 2;

    private bool isOpen = false;
    private bool canOpen = true;

    [SerializeField] private AudioClip flashlightSwitch;
    private AudioSource audioSource;
    
    void Start()
    {
        currentIntensity = spotLight.intensity;
        batteryHealth = maxBatteryHealth;
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (canOpen)
            {
                ToggleLight();
            }          
        }

        if (isOpen)
        {
            batteryHealth -= Time.deltaTime;
        }

        if(batteryHealth <= 0)
        {
            if(batteryCount > 0)
            {
                batteryHealth = maxBatteryHealth;
                batteryCount--;
                return;
            }

            if (isOpen)
            {
                ToggleLight();
            }
            batteryHealth = 0;
            canOpen = false;
        }
    }

    private void ToggleLight()
    {
        isOpen = !isOpen;

        audioSource.PlayOneShot(flashlightSwitch);

        if(isOpen)
        {
            currentIntensity = maxIntensity;
        }
        else
        {
            currentIntensity = 0;
        }

        spotLight.DOIntensity(currentIntensity, 0.75f);
    }
}
