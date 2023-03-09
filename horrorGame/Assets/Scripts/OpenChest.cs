using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject openText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;

    [SerializeField] private bool inReach;
    [SerializeField] private bool isOpen;

    [SerializeField] GameObject drop1;
    [SerializeField] GameObject drop2;
    [SerializeField] private int randomNumber;
    void Start()
    {
        randomNumber = Random.Range(1, 6);
        inReach = false;
        openText.SetActive(false);
    }


    void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            audioSource.PlayOneShot(openSound);
            animator.SetBool("open", true);
            openText.SetActive(false);
            isOpen = true;

            switch (randomNumber)
            {
                case 1:
                    {
                        drop1.GetComponent<MeshRenderer>().enabled = true;
                        drop1.GetComponent<BoxCollider>().enabled = true;
                        break;
                    }
                case 2:
                    {
                        drop2.GetComponent<MeshRenderer>().enabled = true;
                        drop2.GetComponent<BoxCollider>().enabled = true;
                        break;
                    }
                case 3:
                    {
                        drop1.GetComponent<MeshRenderer>().enabled = true;
                        drop1.GetComponent<BoxCollider>().enabled = true;
                        drop2.GetComponent<MeshRenderer>().enabled = true;
                        drop2.GetComponent<BoxCollider>().enabled = true;
                        break;
                    }
                case 4:
                    {
                        
                        break;
                    }
            }
        }
        

        if (isOpen)
        {
            animator.GetComponent<BoxCollider>().enabled = false;
            animator.GetComponent<OpenChest>().enabled = false;
        }
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
