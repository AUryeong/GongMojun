using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private Rigidbody2D rb;
    private Player playerstat;
    private Player player;
    
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
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        playerstat = GetComponent<Player>();
    }
    public void Wind(EWindType WindType,Vector2 dir ,float stat ,float force = 1)//�ٶ��� ����, �淮, ��
    {
        float temp = stat;//�ʱⰪ ����
        switch (WindType)//��ǳ�� ��ǳ�� �߰�����
        {
            case EWindType.Contrarywind://��ǳ
                rb.AddForce(dir * force,ForceMode2D.Force);
                
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
