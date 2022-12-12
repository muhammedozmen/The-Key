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

    public bool canInteract;
    private bool opened;
    
    void Start()
    {
        canInteract = false;
        opened = false;
    }

    
    void Update()
    {
        UIText();
        if(canInteract && Input.GetKeyDown(KeyCode.E))
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

    private void UIText()
    {
        if (canInteract)
        {
            openText.SetActive(true);
        }
        else
        {
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
