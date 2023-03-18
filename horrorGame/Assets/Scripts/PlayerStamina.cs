using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject lackOfAmountText;
    [SerializeField] private TextMeshProUGUI staminaAmountText;
    
    public float staminaAmount;
    public float stamina = 100f;

    public bool isJustUsed;

    private void Start()
    {
        stamina = 100f;
        staminaAmount = 0;
        lackOfAmountText.SetActive(false);
        isJustUsed = false;
    }

    void Update()
    {
        if (stamina <= 0)
        {
            player.GetComponent<FirstPersonMovement>().canRun = false;
        }

        if(stamina > 0 && stamina <= 100)
        {
            player.GetComponent<FirstPersonMovement>().canRun = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                stamina -= Time.deltaTime * 1.5f;
            }
        }

        if (stamina > 100)
        {
            stamina = 100;
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
}
