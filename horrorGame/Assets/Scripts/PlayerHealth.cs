using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject devil;
    [SerializeField] private FadeUI fadeUI;
    [SerializeField] private GameObject cam;

    [SerializeField] private GameObject lackOfAmountText;
    [SerializeField] private TextMeshProUGUI healthAmountText;

    public float healthAmount;
    public float health = 100f;

    public bool isJustUsed;

    void Start()
    {
        healthAmount = 0;
        lackOfAmountText.SetActive(false);
        health = 100f;

        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;

        deathScreen.SetActive(false);
    }

    
    void Update()
    {
        if(health <= 0)
        {
            player.GetComponent<FirstPersonMovement>().enabled = false;
            devil.GetComponent<EnemyDamage>().isAttacking = false;
            cam.GetComponent<FirstPersonLook>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            fadeUI.Fader();
            HUD.SetActive(false);
            StartCoroutine(DeathScreenComes());
        }

        if(health > 100)
        {
            health = 100;
        }

        if (healthAmount == 0 && Input.GetKeyDown(KeyCode.C) && isJustUsed == false)
        {
            lackOfAmountText.SetActive(true);
            StartCoroutine(CloseLackOfAmountText());
        }

        healthAmountText.text = healthAmount.ToString();
    }

    IEnumerator CloseLackOfAmountText()
    {
        yield return new WaitForSeconds(3.25f);
        lackOfAmountText.SetActive(false);
    }

    IEnumerator DeathScreenComes()
    {
        yield return new WaitForSeconds(2);
        deathScreen.SetActive(true);
        Destroy(this);
    }
}
