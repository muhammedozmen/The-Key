using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractCodeBlock : MonoBehaviour
{
    public Animator animator;
    public GameObject interactText;

    //public AudioSource AudioSource;
    //public AudioClip blockTurnSound;

    public int secretCode;
    [SerializeField] private TextMeshPro code1;
    [SerializeField] private TextMeshPro code2;
    [SerializeField] private TextMeshPro code3;
    [SerializeField] private TextMeshPro code4;
    private int turnCounter;
    private int numberCounter;
    

    private bool inReach;

    void Start()
    {
        inReach = false;
        turnCounter = 1;
        numberCounter = 1;
    }


    void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            if (numberCounter < 9)
            {
                secretCode = numberCounter;
                numberCounter++;
            }
            else
            {
                secretCode = numberCounter;
                numberCounter = 0;
            }

            BlockTurns();

            if (turnCounter == 1)
            {
                code1.text = numberCounter.ToString();
                turnCounter++;
            }
            else if(turnCounter == 2)
            {
                code2.text = numberCounter.ToString();
                turnCounter++;
            }
            else if (turnCounter == 3)
            {
                code3.text = numberCounter.ToString();
                turnCounter++;
            }
            else if (turnCounter == 4)
            {
                code4.text = numberCounter.ToString();
                turnCounter = 1;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            interactText.SetActive(false);
        }
    }



    private void BlockTurns()
    {
        animator.SetInteger("turnCounter", turnCounter);
        //AudioSource.PlayOneShot(blockTurnSound);
    }
    
}
