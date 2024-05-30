using System;
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
    [SerializeField] HealthPresenter healthPresenter;
    
    public void Attack(float damage)
    {
       
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D col in hitEnemies) 
        {
            if (col.tag == "player") { healthPresenter?.Damage(Convert.ToInt32(damage));}
            else if (attacker.CompareTag(col.tag)) {  }
            else 
            {
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
