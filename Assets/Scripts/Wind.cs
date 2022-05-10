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
    public void UnitWind(EWindType WindType, Unit unit)//바람의 종류, 방량, 힘
    {
        
        float Defense = unit.defense;//초기값 저장
        float Dmg = unit.dmg;

        //인덱스를 열거형을 int형으로 형변환해 사용
        int index = (int)WindType - 1;

        //float형 배열의 인덱스를 위에서 형변환한 int형 사용

        //Dmg = new float[4]
        //    {player.dmg - (player.dmg / 2), player.dmg + (player.dmg / 2), dmg, dmg}[index];



        switch (WindType)//강풍과 돌풍은 추가예정
        {
            case EWindType.Contrarywind:// 역풍
             
                unit.dmg = Dmg;
                if (unit is Player)
                {
                    unit.defense = Defense + (Defense / 2);
                }
                else if (unit is Enemy)
                {
                    unit.defense = Defense + (Defense / 2);
                }
                //현재 플레이어의 방어력 + (현재 플레이어의 방어력/2)
                break;
            case EWindType.Fairwind://순풍
             
                unit.defense = Defense - (Defense / 2);
                //unit.dmg = dmg;
                break;
            case EWindType.Sirocco://열풍
             
                break;
            case EWindType.Coldwind://냉풍
             
                break;
        }


    }
}
