using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPresenter : MonoBehaviour
{
    [Header("Model")]
    [SerializeField] Health health;

    [Header("View")]
    [SerializeField] RectTransform healthUI;
    [SerializeField] RectTransform healthBar;
    [SerializeField] RectTransform healthValue;

    private void Start()
    {
        if (health != null)
        {
            health.HealthChanged += OnHealthChanged;
        }

        Reset();
    }

    private void OnDestroy()
    {
        if (health != null)
        {
            health.HealthChanged -= OnHealthChanged;
        }
    }

    // send damage to the model
    public void Damage(int amount)
    {
        health?.TakeDamage(amount);
    }

    public void Heal(int amount)
    {
        health?.Increment(amount);
    }

    // send reset to the model
    public void Reset()
    {
        health?.Restore();
    }

    public void UpdateView()
    {
        if (health == null)
            return;

        // format the data for view
        if (healthBar !=null && healthValue != null && health.maxHealth != 0)
        {
            float newWidht = healthBar.rect.width * (health.currentHealth / (float)health.maxHealth);
            healthValue.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidht);
        }
    }

    // listen for model changes and update the view
    public void OnHealthChanged()
    {
        UpdateView();
    }

    void Update()
    {
        healthUI.SetPositionAndRotation(transform.position, healthUI.rotation);
    }
}
