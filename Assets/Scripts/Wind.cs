using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wind : Singleton<Wind>
{
    public Direction direction;
    [SerializeField]
    List<Obj> ObjsinCamera = new List<Obj>();
    public float WindPower;
    public void ChangeDirection(Direction direction)
    {
        this.direction = direction;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject != null)
        {
            Obj obj = collision.GetComponent<Obj>();
            if(obj != null && !ObjsinCamera.Contains(obj))
            {
                ObjsinCamera.Add(obj);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject != null)
        {
            Obj obj = collision.GetComponent<Obj>();
            if (obj != null && ObjsinCamera.Contains(obj))
            {
                ObjsinCamera.Remove(obj);
            }
        }
    }
    void FixedUpdate()
    {
        foreach(Obj obj in ObjsinCamera)
        {
            ApplyWind(obj);
        }
    }
    void ApplyWind(Obj obj)//¹Ù¶÷ÀÇ Á¾·ù, ¹æ·®, Èû
    {
        #region À¯´Ö ½ºÅÝ º¯°æ
        if (obj is Unit)
        {
            Unit unit = (obj as Unit);
            float Defense = unit.defaultDfs;
            float Dmg = unit.defaultDmg;
            float Gravity = unit.GravityScale;

            if (direction == Direction.Up)
            {
                if (unit is Player)
                {
                    unit.Rb.gravityScale = Gravity - (Gravity / 2);
                }
                else if (unit is Enemy)
                {
                    unit.Rb.gravityScale = Gravity - (Gravity / 4);
                }
            }
            else if (direction == Direction.Down)
            {
                if (unit is Player)
                {
                    unit.Rb.gravityScale = Gravity + (Gravity / 2);
                }
                else if (unit is Enemy)
                {
                    unit.Rb.gravityScale = Gravity + (Gravity / 4);
                }
            }
            else if (unit.direction != direction)
            {
                unit.Dmg = Dmg;
                if (unit is Player)
                {
                    unit.Dfs = Defense + (Defense / 2);
                    unit.Dmg = Dmg - (Dmg / 2);
                }
                else if (unit is Enemy)
                {
                    unit.Dfs = Defense + (Defense / 4);
                }
            }
            else
            {
                if (unit is Player)
                {
                    unit.Dfs = Defense - (Defense / 2);
                    unit.Dmg = Dmg + (Dmg / 2);
                }
                else if (unit is Enemy)
                {
                    unit.Dmg = Dmg + (Dmg / 4);
                }
            }
        }
        #endregion
        if(direction == Direction.Right)
        {
            if(obj is Player)
            {
                obj.Rb.AddForce(Vector2.right * WindPower * 2, ForceMode2D.Force);
            }
            else
            {
                obj.Rb.AddForce(Vector2.right * WindPower, ForceMode2D.Force);
            }
        }
        else if (direction == Direction.Left)
        {
            if (obj is Player)
            {
                obj.Rb.AddForce(Vector2.left * WindPower * 2, ForceMode2D.Force);
            }
            else
            {
                
                obj.Rb.AddForce(Vector2.left * WindPower, ForceMode2D.Force);
            }
        }
        else if (direction == Direction.Up)
        {
            if (!(obj is Unit))
            {
                obj.Rb.AddForce(Vector2.up * WindPower * 2.5f, ForceMode2D.Force);
            }
        }
        else if (direction == Direction.Down)
        {
            if (!(obj is Unit))
            {
                obj.Rb.AddForce(Vector2.down * WindPower * 2.5f, ForceMode2D.Force);
            }
        }
    }
}