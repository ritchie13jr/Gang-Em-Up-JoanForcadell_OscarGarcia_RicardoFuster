using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] protected float verticalSpeed;
    [SerializeField] protected float horizontalSpeed;

    protected Rigidbody2D rb;
    protected SpriteRenderer sr;
    protected Animator an;
    protected static Vector2 LimitsY = new Vector2(-5.01f, -2.36f);

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
    }

    public void Move(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x * horizontalSpeed, direction.y * verticalSpeed);

        FlipSprite(direction);
        ClampPosition();

        if (an != null)
        {
            bool isWalking = direction.magnitude != 0;
            SetAnimation("IsWalking", isWalking);
        }
    }

    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }

    protected void FlipSprite(Vector2 direction)
    {
        if (direction.x != 0)
        {
            sr.flipX = direction.x < 0;
        }
    }

    protected void SetAnimation(string parameter, bool value)
    {
        if (an != null)
        {
            an.SetBool(parameter, value);
        }
    }

    void Update()
    {
        ClampPosition();
    }

    protected void ClampPosition()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, LimitsY.x, LimitsY.y), transform.position.z);
    }
}

