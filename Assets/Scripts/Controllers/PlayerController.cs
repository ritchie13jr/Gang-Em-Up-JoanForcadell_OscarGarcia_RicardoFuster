using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movimiento movimiento;
    private AttackBehavior attackBehavior;
    protected Animator an;

    void Start()
    {
        movimiento = GetComponent<Movimiento>();
        attackBehavior = GetComponent<AttackBehavior>();
        an = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movimiento.Move(movementInput);

        if (Input.GetMouseButtonDown(0))
        {
            if (an != null) { an.SetTrigger("SendPunch"); }
            attackBehavior.Attack(50);
        }
    }
}
