using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private PlayerHealth playerHealth;
    [SerializeField] private Image healthBar;
    [SerializeField] private float MaxHealth = 100f;
    public float CurrentHealth;

    void Start()
    {
        healthBar = GetComponent<Image>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    
    void Update()
    {
        CurrentHealth = playerHealth.health;
        healthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
