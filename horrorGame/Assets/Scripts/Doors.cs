using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Animator animator;
    public GameObject openText;

    public AudioSource AudioSource;
    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;

    private bool inReach;
    private bool opened;
    
    void Start()
    {
        inReach = false;
        opened = false;
    }

    
    void Update()
    {    
        if(inReach && Input.GetKeyDown(KeyCode.E))
        {
            if(opened == false)
            {
                DoorOpens();
                opened = true;
            }
            else
            {
                DoorCloses();
                opened=false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }

    

    private void DoorOpens()
    {
        animator.SetBool("isDoorOpen", true);
        AudioSource.PlayOneShot(doorOpenSound);
    }

    private void DoorCloses()
    {
        animator.SetBool("isDoorOpen", false);
        AudioSource.PlayOneShot(doorCloseSound);
    }
}
