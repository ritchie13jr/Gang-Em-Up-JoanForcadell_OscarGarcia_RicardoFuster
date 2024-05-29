using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public GameObject attacker;
    private HealthPresenter healthPresenter;
    private void Update() 
    {
        healthPresenter = GetComponent<HealthPresenter>();
    }
    public void Attack(int damage)
    {
       
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D col in hitEnemies) 
        {
            if (attacker.CompareTag(col.tag)) {  }
            else 
            {
                healthPresenter?.Damage(damage);
                col.GetComponent<Health>().TakeDamage(damage);
            }
           
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) { return; }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange); 
    }
}
