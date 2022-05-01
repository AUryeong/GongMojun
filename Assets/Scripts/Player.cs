using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpSpeed;
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer spriteRenderer;

    public float LastX = 0;
    public float LastY = 0;
    public WindType windType;
    public enum WindType
    {
        Right,
        Left
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rigid.AddForce(Vector2.up * Speed * JumpSpeed * 100);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            windType = (WindType)(((int)windType + 1) % 2);
        }
        if (rigid.velocity.x != 0 || rigid.velocity.y != 0)
        {
            LastX = rigid.velocity.x;
            LastY = rigid.velocity.y;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(Vector2.right * Speed);
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(Vector2.left * Speed);
            spriteRenderer.flipX = true;
        }
        if ((Input.GetKey(KeyCode.D) && rigid.velocity.x > 0.2f) || (Input.GetKey(KeyCode.A) && rigid.velocity.x < -0.2f))
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        if (windType == WindType.Right)
        {
            rigid.AddForce(Vector2.right * 20);
        }
        else
        {
            rigid.AddForce(Vector2.left * 10);
        }
    }
}
