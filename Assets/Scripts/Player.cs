using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpSpeed;
    Rigidbody2D rigid;

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
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(Vector2.left * Speed);
        }
        if(windType == WindType.Right)
        {
            rigid.AddForce(Vector2.right * 20);
        }
        else
        {
            rigid.AddForce(Vector2.left * 10);
        }
    }
}
