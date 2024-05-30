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
 public int CurrentHealth {get => currentHealth; set => currentHealth = value;}
 public int MinHealth => minHealth;
 public int MaxHealth => maxHealth;
 public GameObject character;
 
 public void Increment (int amount) 
 {
    currentHealth += amount;
    currentHealth = Math.Clamp(currentHealth, minHealth, maxHealth);
    UpdateHealth(); 
 }
 public void Decrement (int amount) 
 {
    currentHealth -= amount;
    currentHealth = Math.Clamp(currentHealth, minHealth, maxHealth);
     if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    UpdateHealth();
 }
 public void Restore() 
 {
    currentHealth = maxHealth;
    UpdateHealth();
 }

 public void UpdateHealth() 
 {
    HealthChanged.Invoke();
 }
   private void Die()
    {
        if (character.CompareTag("Enemy"))
        {
            character.SetActive(false);
        }
        else
        Destroy(character);
    }
}
