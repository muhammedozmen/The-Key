using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject boxKeyNeeded;
    [SerializeField] private GameObject openText;
    [SerializeField] private GameObject keyMissingText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;

    [SerializeField] private bool inReach;
    [SerializeField] private bool isOpen;

    [SerializeField] GameObject drop1;
    [SerializeField] GameObject drop2;
    [SerializeField] GameObject drop3;
    [SerializeField] GameObject drop4;
    [SerializeField] GameObject drop5;
    [SerializeField] GameObject drop6;
    [SerializeField] private int randomNumber;
    void Start()
    {
        randomNumber = Random.Range(1, 6);
        inReach = false;
        openText.SetActive(false);
        keyMissingText.SetActive(false);
    }

    
    void Update()
    {
        if(boxKeyNeeded.activeInHierarchy == true && inReach && Input.GetKeyDown(KeyCode.E))
        {
            boxKeyNeeded.SetActive(false);
            audioSource.PlayOneShot(openSound);
            animator.SetBool("open", true);
            openText.SetActive(false);
            keyMissingText.SetActive(false);
            isOpen = true;

            switch (randomNumber)
            {
                case 1:
                    {
                        drop1.SetActive(true);
                        break;
                    }
                case 2:
                    {
                        drop2.SetActive(true);
                        break;
                    }
                case 3:
                    {
                        drop3.SetActive(true);
                        break;
                    }
                case 4:
                    {
                        drop4.SetActive(true);
                        break;
                    }
                case 5:
                    {
                        drop5.SetActive(true);
                        break;
                    }
                case 6:
                    {
                        drop6.SetActive(true);
                        break;
                    }
            }
        }
        else if(boxKeyNeeded.activeInHierarchy == false && inReach && Input.GetKeyDown(KeyCode.E))
        {
            openText.SetActive(false);
            keyMissingText.SetActive(true);
        }

        if (isOpen)
        {
            animator.GetComponent<BoxCollider>().enabled = false;
            animator.GetComponent<OpenBox>().enabled = false;
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
