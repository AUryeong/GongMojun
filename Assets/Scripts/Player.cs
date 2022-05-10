using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : Unit
{

    [Header("플레이어 스탯")]

    


    [Space(20f)]

    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer spriteRenderer;

    public float LastX = 0;
    public float LastY = 0;
    public EWindDir eWindDir;

    public enum EWindDir//E는 (enum타입이라서 명시)
    {
        Right = 1,
        Left = -1
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    //public void SetStat(float dmg , float atspd, float Speed, float defense)
    //{
    //    this.dmg = dmg;
    //    this.atspd = atspd;
    //    this.Speed = Speed;
    //    this.defense = defense;
    //}

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

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
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
        //    #region 바람종류 바꾸기 키입력
        //    if (Input.GetKeyDown(KeyCode.Alpha0))
        //    {
        //        intwindtype = (int)EWindType.Contrarywind;
        //    }
        //    else if (Input.GetKeyDown(KeyCode.Alpha1))
        //    {
        //        intwindtype = (int)EWindType.Fairwind;
        //    }
        //    else if (Input.GetKeyDown(KeyCode.Alpha2))
        //    {
        //        intwindtype = (int)EWindType.Sirocco;
        //    }
        //    else if (Input.GetKeyDown(KeyCode.Alpha3))
        //    {
        //        intwindtype = (int)EWindType.Coldwind;
        //    }
        //    else if (Input.GetKeyDown(KeyCode.Alpha4))
        //    {
        //        intwindtype = (int)EWindType.Gale;
        //    }
        //    else if (Input.GetKeyDown(KeyCode.Alpha5))
        //    {
        //        intwindtype = (int)EWindType.Squall;
        //    }
        //    #endregion
        //}
    }

}
