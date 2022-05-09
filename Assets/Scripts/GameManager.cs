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
    Player,
    Enemy
}

public class GameManager : MonoBehaviour
{
    public List<EWindType> eWindTypes = new List<EWindType>();


    private Rigidbody2D rb;
    private Player player;
    private Enemy enemy;
    
    
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                FindObjectOfType<GameManager>();
            }
            return instance;
        }
        
    }
    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        enemy = GetComponent<Enemy>();
    }
    public void Wind(EWindType WindType,Vector2 dir ,float stat ,float force = 1)//�ٶ��� ����, �淮, ��
    {
        float temp = stat;//�ʱⰪ ����
        switch (WindType)//��ǳ�� ��ǳ�� �߰�����
        {
            case EWindType.Contrarywind://��ǳ
                rb.AddForce(dir * force,ForceMode2D.Force);

                player.defense = player.defense + (player.defense / 2);
                player.Dmg = player.Dmg - (player.Dmg / 4);

                enemy.defense = enemy.defense + (enemy.defense / 4);
                //���� �÷��̾��� ���� + (���� �÷��̾��� ����/2)
                break;
            case EWindType.Fairwind://��ǳ
                rb.AddForce(dir * force, ForceMode2D.Force);

                break;
            case EWindType.Sirocco://��ǳ
                rb.AddForce(dir * force, ForceMode2D.Force);
                break;
            case EWindType.Coldwind://��ǳ
                rb.AddForce(dir * force, ForceMode2D.Force);
                break;
        }

    }
}
