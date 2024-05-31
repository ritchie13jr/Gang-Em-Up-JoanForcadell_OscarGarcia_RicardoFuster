using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayersHealth : MonoBehaviour
{
    public event Action HealthChanged;
    [SerializeField] private int minHealth = 0;
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public int MinHealth => minHealth;
    public int MaxHealth => maxHealth;
    public GameObject character;

    void Awake()
    {
        if (character == null)
        {
            character = this.gameObject;
        }
        currentHealth = maxHealth;  // Inicializa currentHealth con maxHealth
    }

    public void Increment(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, minHealth, maxHealth);  // Usa Mathf en lugar de Math
        UpdateHealth();
    }

    public void Decrement(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, minHealth, maxHealth);  // Usa Mathf en lugar de Math
        UpdateHealth();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Restore()
    {
        currentHealth = maxHealth;
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        if (HealthChanged != null)
        {
            HealthChanged.Invoke();
        }
    }

    private void Die()
    {
        if (character != null)
        {
            if (character.CompareTag("Enemy"))
            {
                character.SetActive(false);
            }
            else
            {
                Destroy(character);
            }
        }
    }
}
