using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obj : MonoBehaviour
{

    public bool isWind = true;
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wind"))
        {
            isWind = true;
        }
    }
    protected void FixedUpdate()
    {
        
    }
}
