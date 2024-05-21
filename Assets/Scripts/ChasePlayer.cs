using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] private float chaseRange;
    private float attackRange = 1.2f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public bool IsPlayerInChaseRange()
    {
        if (player == null) return false;
        return Vector2.Distance(transform.position, player.position) <= chaseRange;
    }
    public bool IsPlayerInAttackRange() 
    {
        if (player == null) return false;
        return Vector2.Distance(transform.position, player.position) <= attackRange;
    }

    public Vector2 GetChaseDirection()
    {
        if (player == null) return Vector2.zero;
        return (player.position - transform.position).normalized;
    }

    public Vector2 GetPlayerPosition()
    {
        if (player == null) return Vector2.zero;
        return player.position;
    }
}
