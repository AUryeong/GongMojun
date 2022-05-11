using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EWindType
{
    Contrarywind = 1,//¿ªÇ³
    Fairwind,//¼øÇ³
    Sirocco,//¿­Ç³
    Coldwind,//³ÃÇ³
    Gale,//°­Ç³
    Squall//µ¹Ç³
}
public enum EObjType
{
    player,
    enemy
}
public class Wind : MonoBehaviour
{
    private EWindType windtype = EWindType.Contrarywind;

    public Vector2 dir;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            UnitWind(windtype, collision.GetComponent<Unit>());
        }
    }
    public void UnitWind(EWindType WindType, Unit unit)//¹Ù¶÷ÀÇ Á¾·ù, ¹æ·®, Èû
    {

        float Defense = unit.defaultDfs;
        float Dmg = unit.defaultDmg;
        float Gravity = unit.defaultGvScale;

        //ÀÎµ¦½º¸¦ ¿­°ÅÇüÀ» intÇüÀ¸·Î Çüº¯È¯ÇØ »ç¿ë
        int index = (int)WindType - 1;

        //floatÇü ¹è¿­ÀÇ ÀÎµ¦½º¸¦ À§¿¡¼­ Çüº¯È¯ÇÑ intÇü »ç¿ë

        //Dmg = new float[4]
        //    {player.dmg - (player.dmg / 2), player.dmg + (player.dmg / 2), dmg, dmg}[index];



        switch (WindType)//°­Ç³°ú µ¹Ç³Àº Ãß°¡¿¹Á¤
        {
            #region ¹Ù¶÷Á¾·ù¿¡ µû¸¥ È¿°ú
            case EWindType.Contrarywind:// ¿ªÇ³

                unit.dmg = Dmg;
                if (unit is Player)
                {
                    unit.dfs = Defense + (Defense / 2);
                    unit.dmg = Dmg - (Dmg / 2);
                }
                else if (unit is Enemy)
                {
                    unit.dfs = Defense + (Defense / 4);
                }
                break;
            case EWindType.Fairwind://¼øÇ³
                if (unit is Player)
                {
                    unit.dfs = Defense - (Defense / 2);
                    unit.dmg = Dmg + (Dmg / 2);
                }
                else if (unit is Enemy)
                {
                    unit.dmg = Dmg + (Dmg / 4);
                }

                break;
            case EWindType.Sirocco://¿­Ç³
                if(unit is Player)
                {
                    unit.gvScale = Gravity - (Gravity / 2);
                }
                else if(unit is Enemy)
                {
                    unit.gvScale = Gravity - (Gravity / 4);
                }
                break;
            case EWindType.Coldwind://³ÃÇ³
                if(unit is Player)
                {
                    unit.gvScale = Gravity + (Gravity / 2);
                }
                else if(unit is Enemy)
                {
                    unit.gvScale = Gravity + (Gravity / 4);
                }
                break;
                #endregion
        }


    }
}
