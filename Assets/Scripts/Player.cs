using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    [Header("ÇÃ·¹ÀÌ¾î ½ºÅÈ")]
    public float Dmg;
    public float atspd;
    public float defense;
    public float stamina;
    public float Speed;
    public float JumpSpeed;


    [Space(20f)]

    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer spriteRenderer;

    public float LastX = 0;
    public float LastY = 0;
    public EWindDir eWindDir;

    public enum EWindDir//E´Â (enumÅ¸ÀÔÀÌ¶ó¼­ ¸í½Ã)
    {
        Right,
        Left
    }
    public enum EIsWind
    {
        Contrarywind = 1,//¿ªÇ³
        Fairwind,//¼øÇ³
        Sirocco,//¿­Ç³
        Coldwind,//³ÃÇ³
        Gale,//°­Ç³
        Squall//µ¹Ç³
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
            eWindDir = (EWindDir)(((int)eWindDir + 1) % 2);
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
            animator.speed = Mathf.Abs(rigid.velocity.x) / 10;
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        if (eWindDir == EWindDir.Right)
        {
            rigid.AddForce(Vector2.right * 20);
        }
        else
        {
            rigid.AddForce(Vector2.left * 10);
        }
    }

}
