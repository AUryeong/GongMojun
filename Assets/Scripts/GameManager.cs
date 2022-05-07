using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Rigidbody2D rb;
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
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }
    public void Wind(EWindType WindType,Vector2 dir ,float force = 1)//�ٶ��� ����, �淮, ��
    {
        switch (WindType)//��ǳ�� ��ǳ�� �߰�����
        {
            case EWindType.Contrarywind://��ǳ
                rb.AddForce(dir * force,ForceMode2D.Force);
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
