using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLockedChest : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject boxKeyNeeded;
    [SerializeField] private GameObject openText;
    [SerializeField] private GameObject keyMissingText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private GameObject keyGUI;

    [SerializeField] private BoxCollider paperCollider;

    [SerializeField] private bool inReach;
    [SerializeField] private bool isOpen;

    void Start()
    {
        paperCollider.enabled = false;
        inReach = false;
        openText.SetActive(false);
        keyMissingText.SetActive(false);
    }

    
    void Update()
    {
        if(boxKeyNeeded.activeInHierarchy == true && inReach && Input.GetKeyDown(KeyCode.E))
        {
            paperCollider.enabled = false;
            boxKeyNeeded.SetActive(false);
            audioSource.PlayOneShot(openSound);
            animator.SetBool("open", true);
            openText.SetActive(false);
            keyMissingText.SetActive(false);
            isOpen = true;
            keyGUI.SetActive(false);
        }
        else if(boxKeyNeeded.activeInHierarchy == false && inReach && Input.GetKeyDown(KeyCode.E))
        {
            openText.SetActive(false);
            keyMissingText.SetActive(true);
        }

        if (isOpen)
        {
            animator.GetComponent<BoxCollider>().enabled = false;
            animator.GetComponent<OpenLockedChest>().enabled = false;
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
            keyMissingText.SetActive(false);
        }
    }
}
