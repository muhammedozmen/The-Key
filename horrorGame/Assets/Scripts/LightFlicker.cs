using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light lightObject;
    public Light lightObject2;

    public GameObject halo;
    public GameObject fire;
    public GameObject smoke;

    public bool isDevilTriggered;
    

    //[SerializeField] private AudioSource lightSound;

    [SerializeField] private float minTime, maxTime, timer;
    
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }

    
    void Update()
    {
        if (isDevilTriggered)
        {        
            LightFlickering();
        }  
    }

    private void LightFlickering()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            lightObject.enabled = !lightObject.enabled;
            lightObject2.enabled = !lightObject2.enabled;
            halo.SetActive(!halo.activeInHierarchy);
            fire.SetActive(!fire.activeInHierarchy);
            smoke.SetActive(!smoke.activeInHierarchy);
            timer = Random.Range(minTime, maxTime);
        }
    }

    
}
