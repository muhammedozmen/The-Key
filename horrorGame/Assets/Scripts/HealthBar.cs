using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    public float CurrentHealth;
    [SerializeField] private float MaxHealth = 100f;
    private PlayerHealth playerHealth;
    
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
