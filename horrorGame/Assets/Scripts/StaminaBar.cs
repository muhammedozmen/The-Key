using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private PlayerStamina playerStamina;
    [SerializeField] private Image staminaBar;
    [SerializeField] private float MaxStamina = 100f;
    public float CurrentStamina;
    

    void Start()
    {
        staminaBar = GetComponent<Image>();
        playerStamina = FindObjectOfType<PlayerStamina>();
    }


    void Update()
    {
        CurrentStamina = playerStamina.stamina;
        staminaBar.fillAmount = CurrentStamina / MaxStamina;
    }
}
