using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject lackOfAmountText;
    [SerializeField] private TextMeshProUGUI staminaAmountText;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip breathing;
    
    public float staminaAmount;
    public float stamina = 50f;
    [SerializeField] private float exhaustAmount;

    public bool isJustUsed;
    private bool isRunning;
    private bool canRefull;

    private void Start()
    {
        exhaustAmount = 0;
        stamina = 50f;
        staminaAmount = 0;
        lackOfAmountText.SetActive(false);
        isJustUsed = false;
        isRunning = false;
        canRefull = false;
    }

    void Update()
    {
        if(stamina <= 0)
        {
            player.GetComponent<FirstPersonMovement>().canRun = false;
            StartCoroutine(CanRefullStamina());
        }

        if(stamina > 0 && stamina <= 50)
        {
            player.GetComponent<FirstPersonMovement>().canRun = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                canRefull = false;
                isRunning = true;
                stamina -= Time.deltaTime * 1.5f;
                exhaustAmount += Time.deltaTime * 2.5f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isRunning = false;
                if(exhaustAmount > 15)
                {
                    audioSource.PlayOneShot(breathing);
                } 
                StartCoroutine(CanRefullStamina());
            }
        }

        if (canRefull == true)
        {
            stamina += Time.deltaTime * 1.5f;
        }

        if (stamina > 50)
        {
            stamina = 50;
        }

        if (staminaAmount == 0 && Input.GetKeyDown(KeyCode.V) && isJustUsed == false)
        {
            lackOfAmountText.SetActive(true);
            StartCoroutine(CloseLackOfAmountText());
        }

        staminaAmountText.text = staminaAmount.ToString();
    }

    IEnumerator CloseLackOfAmountText()
    {
        yield return new WaitForSeconds(3.25f);
        lackOfAmountText.SetActive(false);
    }

    IEnumerator CanRefullStamina()
    {
        if (isRunning == false)
        {
            exhaustAmount = 0;
        }
        yield return new WaitForSeconds(4f);
        canRefull = true;

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
    
}
