using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{

    [SerializeField]
    public float maxHealth = 100f;
    [SerializeField]
    public float currentHealth;
    public GameObject character;
    public event Action HealthChanged;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealth();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        if (character.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
        else
        Destroy(gameObject);
    }

    public void UpdateHealth()
    {
        HealthChanged.Invoke();
    }
}
