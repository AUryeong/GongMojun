using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Obj : MonoBehaviour
{
    Rigidbody2D rb;

    public bool isWind = true;
    [SerializeField]
    private Wind wind;
    [SerializeField]
    private float force = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wind"))
        {
            isWind = true;
        }
    }
    protected virtual void FixedUpdate()
    {
        rb.AddForce(wind.dir * force, ForceMode2D.Force);
    }
}
