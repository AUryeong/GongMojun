using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obj : MonoBehaviour
{
    public bool isWind = true;
    public int intwindtype = (int)EWindType.Contrarywind;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wind"))
        {
            isWind = true;
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            intwindtype = (int)EWindType.Contrarywind;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            intwindtype = (int)EWindType.Fairwind;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            intwindtype = (int)EWindType.Sirocco;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            intwindtype = (int)EWindType.Coldwind;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            intwindtype = (int)EWindType.Gale;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            intwindtype = (int)EWindType.Squall;
        }
    }
   

}
