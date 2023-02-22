using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] private Image staminaBar;
    public float CurrentStamina;
    [SerializeField] private float MaxStamina = 200f;
    private PlayerStamina playerStamina;

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
