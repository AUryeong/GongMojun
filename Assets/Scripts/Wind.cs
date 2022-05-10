using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EWindType
{
    Contrarywind = 1,//��ǳ
    Fairwind,//��ǳ
    Sirocco,//��ǳ
    Coldwind,//��ǳ
    Gale,//��ǳ
    Squall//��ǳ
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
    public void UnitWind(EWindType WindType, Unit unit)//�ٶ��� ����, �淮, ��
    {
        
        float Defense = unit.defense;//�ʱⰪ ����
        float Dmg = unit.dmg;

        //�ε����� �������� int������ ����ȯ�� ���
        int index = (int)WindType - 1;

        //float�� �迭�� �ε����� ������ ����ȯ�� int�� ���

        //Dmg = new float[4]
        //    {player.dmg - (player.dmg / 2), player.dmg + (player.dmg / 2), dmg, dmg}[index];



        switch (WindType)//��ǳ�� ��ǳ�� �߰�����
        {
            case EWindType.Contrarywind:// ��ǳ
             
                unit.dmg = Dmg;
                if (unit is Player)
                {
                    unit.defense = Defense + (Defense / 2);
                }
                else if (unit is Enemy)
                {
                    unit.defense = Defense + (Defense / 2);
                }
                //���� �÷��̾��� ���� + (���� �÷��̾��� ����/2)
                break;
            case EWindType.Fairwind://��ǳ
             
                unit.defense = Defense - (Defense / 2);
                //unit.dmg = dmg;
                break;
            case EWindType.Sirocco://��ǳ
             
                break;
            case EWindType.Coldwind://��ǳ
             
                break;
        }


    }
}
