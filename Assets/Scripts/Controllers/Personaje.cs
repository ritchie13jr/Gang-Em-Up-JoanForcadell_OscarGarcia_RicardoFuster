using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Personaje : MonoBehaviour
{
    static Vector2 LimitsY = new Vector2(-5.01f,-2.36f);

    [SerializeField]
    float verticalSpeed;
    [SerializeField]
    float horizontalSpeed;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator an;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
    }

    Vector2 control;
    // Update is called once per frame
    void Update()
    {
        control = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        SpriteFlip();
        Attack();
        MovementPersonaje();
        
    }

    void SpriteFlip()
    {
        if (control.x != 0)
        {
            sr.flipX = control.x < 0;
        }
    }

    void MovementPersonaje()
    {
        if (!an.GetCurrentAnimatorStateInfo(0).IsName("Punch") &&
            !an.GetCurrentAnimatorStateInfo(0).IsName("GetPunch"))
        {
            an.SetBool("IsWalking", control.magnitude != 0);
            rb.velocity = new Vector2(control.x * horizontalSpeed, control.y * verticalSpeed);
            transform.position = new Vector3(transform.position.x,
            Mathf.Clamp(transform.position.y, LimitsY.x, LimitsY.y), transform.position.z);
        }
        else 
        {
            StopCharacter();
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            an.SetTrigger("SendPunch");
        }
    }

    void StopCharacter()
    {
        rb.velocity = Vector2.zero;
    }
}
