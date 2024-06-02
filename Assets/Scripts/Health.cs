using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public SpriteRenderer healthBar;
    public Transform healthBarTransform;
    [SerializeField]
    public float maxHealth = 100f;
    [SerializeField]
    public float currentHealth;
    public GameObject character;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
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

    private void Update()
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        healthBarTransform.transform.localScale = new Vector3(healthPercentage * 0.7f, 0.07412712f, 1);
        healthBar.color = Color.Lerp(Color.red, Color.green, healthPercentage);
        Debug.Log(currentHealth);
    }
}
