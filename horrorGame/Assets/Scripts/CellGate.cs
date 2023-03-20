using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CellGate : MonoBehaviour
{
    public GameObject openText;

    public Animator animator;
    
    public AudioSource AudioSource;
    public AudioClip gateOpenSound;
    public AudioClip gateCloseSound;

    private bool inReach;
    private bool isOpened;
    private bool isSoundPlaying;

    void Start()
    {
        isOpened = false;
        isSoundPlaying = false;
        inReach = false;
        openText.SetActive(false);
    }


    void Update()
    {
        if (isOpened == false && inReach && Input.GetKeyDown(KeyCode.E))
        {
            if(isSoundPlaying == false)
            {
                AudioSource.PlayOneShot(gateOpenSound);              
            }
            animator.SetBool("isCellGateOpen", true);
            openText.SetActive(false);
        }

        if (isOpened == true && inReach && Input.GetKeyDown(KeyCode.E))
        {
            if (isSoundPlaying == false)
            {
                AudioSource.PlayOneShot(gateOpenSound);
            }
            animator.SetBool("isCellGateOpen", false);
            openText.SetActive(false);
        }
    }

    private void FirstEvent()
    {
        isSoundPlaying = !isSoundPlaying;
    }

    private void SecondEvent()
    {
        isOpened = !isOpened;
        isSoundPlaying = !isSoundPlaying;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
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
}
