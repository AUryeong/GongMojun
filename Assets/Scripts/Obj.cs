using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obj : MonoBehaviour
{

    public bool isWind = true;
    protected int intwindtype = (int)EWindType.Contrarywind;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wind"))
        {
            isWind = true;
        }
    }
    protected void FixedUpdate()
    {
        #region 바람종류 바꾸기 키입력
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
        #endregion
    }
}
