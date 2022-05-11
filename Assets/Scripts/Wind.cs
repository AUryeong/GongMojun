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
        #region �ٶ����� �ٲٱ� Ű�Է�
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
    public void UnitWind(EWindType WindType, Unit unit)//�ٶ��� ����, �淮, ��
    {

        float Defense = unit.defaultDfs;
        float Dmg = unit.defaultDmg;
        float Gravity = unit.defaultGvScale;

        //�ε����� �������� int������ ����ȯ�� ���
        int index = (int)WindType - 1;

        //float�� �迭�� �ε����� ������ ����ȯ�� int�� ���
        //Dmg = new float[4]
        //    {player.dmg - (player.dmg / 2), player.dmg + (player.dmg / 2), dmg, dmg}[index];
        switch (WindType)//��ǳ�� ��ǳ�� �߰�����
        {
            #region �ٶ������� ���� ȿ��
            case EWindType.Contrarywind:// ��ǳ

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
            case EWindType.Fairwind://��ǳ
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
            case EWindType.Sirocco://��ǳ
                if(unit is Player)
                {
                    unit.gvScale = Gravity - (Gravity / 2);
                }
                else if(unit is Enemy)
                {
                    unit.gvScale = Gravity - (Gravity / 4);
                }
                break;
            case EWindType.Coldwind://��ǳ
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
