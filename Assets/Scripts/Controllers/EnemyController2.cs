using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    [SerializeField] private float patrolInterval = 2f;
    [SerializeField] private Vector2 patrolAreaMin;
    [SerializeField] private Vector2 patrolAreaMax;
    [SerializeField] private float patrolSpeed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float stoppingDistance = 0.5f;

    private float attackTimer;
    private Movimiento movimiento;
    private Vector2 nextPatrolPoint;
    private float patrolTimer;
    private ChasePlayer chasePlayer;
    private AttackBehavior attackBehavior;
    private Animator animator;

    void Start()
    {
        movimiento = GetComponent<Movimiento>();
        chasePlayer = GetComponent<ChasePlayer>();
        SetNextPatrolPoint();
        patrolTimer = patrolInterval;
        attackBehavior = GetComponent<AttackBehavior>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        patrolTimer -= Time.deltaTime;
        attackTimer += Time.deltaTime;

        if (chasePlayer.IsPlayerInAttackRange())
        {
            if (animator != null) { animator.SetTrigger("SendPunch"); }
            if (attackTimer >= 1f) 
            {
                
                attackBehavior.Attack(25);
                attackTimer = 0;
            }
        }
        else if (chasePlayer.IsPlayerInChaseRange()) 
        {
            Chase();
        }
        else 
        {
            if (patrolTimer <= 0)
            {
                SetNextPatrolPoint();
                patrolTimer = patrolInterval;
            }
            Patrol();
        }
    }

    private void Patrol()
    {
        Vector2 direction = (nextPatrolPoint - (Vector2)transform.position).normalized;
        movimiento.Move(direction * patrolSpeed);

        if (Vector2.Distance(transform.position, nextPatrolPoint) < 0.1f)
        {
            SetNextPatrolPoint();
        }
    }

    private void Chase()
    {
        Vector2 direction = chasePlayer.GetChaseDirection();
        float distanceToPlayer = Vector2.Distance(transform.position, chasePlayer.GetPlayerPosition());

        if (distanceToPlayer > stoppingDistance)
        {
            movimiento.Move(direction * chaseSpeed);
        }
        else
        {
            movimiento.Stop(); // Detener movimiento si está muy cerca del jugador
        }
    }

    private void SetNextPatrolPoint()
    {
        nextPatrolPoint = new Vector2(
            Random.Range(patrolAreaMin.x, patrolAreaMax.x),
            Random.Range(patrolAreaMin.y, patrolAreaMax.y)
        );
    }

}
