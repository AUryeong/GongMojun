using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EWindType
{
    Contrarywind = 1,//역풍
    Fairwind,//순풍
    Sirocco,//열풍
    Coldwind,//냉풍
    Gale,//강풍
    Squall//돌풍
}
public class Wind : MonoBehaviour
{
    private EWindType windtype = EWindType.Contrarywind;

    [HideInInspector]
    public Vector2 dir;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        #region 바람종류 바꾸기 키입력
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            windtype = EWindType.Contrarywind;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            windtype = EWindType.Fairwind;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            windtype = EWindType.Sirocco;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            windtype = EWindType.Coldwind;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            windtype = EWindType.Gale;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            windtype = EWindType.Squall;
        }
        #endregion
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            UnitWind(windtype, collision.GetComponent<Unit>());
        }
    }
    public void UnitWind(EWindType WindType, Unit unit)//바람의 종류, 방량, 힘
    {

        float Defense = unit.defaultDfs;
        float Dmg = unit.defaultDmg;
        float Gravity = unit.defaultGvScale;

        //인덱스를 열거형을 int형으로 형변환해 사용
        int index = (int)WindType - 1;

        //float형 배열의 인덱스를 위에서 형변환한 int형 사용
        //Dmg = new float[4]
        //    {player.dmg - (player.dmg / 2), player.dmg + (player.dmg / 2), dmg, dmg}[index];
        switch (WindType)//강풍과 돌풍은 추가예정
        {
            #region 바람종류에 따른 효과
            case EWindType.Contrarywind:// 역풍

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
            case EWindType.Fairwind://순풍
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
            case EWindType.Sirocco://열풍
                if(unit is Player)
                {
                    unit.gvScale = Gravity - (Gravity / 2);
                }
                else if(unit is Enemy)
                {
                    unit.gvScale = Gravity - (Gravity / 4);
                }
                break;
            case EWindType.Coldwind://냉풍
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
