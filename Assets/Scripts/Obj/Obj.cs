using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Obj : MonoBehaviour
{
    protected Rigidbody2D rb;


    public Rigidbody2D Rb
    {
        get { return rb; }
    }


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

}
