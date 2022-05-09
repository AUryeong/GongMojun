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
    public void Wind(EWindType WindType,Vector2 dir ,float stat ,float force = 1)//바람의 종류, 방량, 힘
    {
        float temp = stat;//초기값 저장
        switch (WindType)//강풍과 돌풍은 추가예정
        {
            case EWindType.Contrarywind://역풍
                rb.AddForce(dir * force,ForceMode2D.Force);
                
                //현재 플레이어의 방어력 + (현재 플레이어의 방어력/2)
                break;
            case EWindType.Fairwind://순풍
                rb.AddForce(dir * force, ForceMode2D.Force);

                break;
            case EWindType.Sirocco://열풍
                rb.AddForce(dir * force, ForceMode2D.Force);
                break;
            case EWindType.Coldwind://냉풍
                rb.AddForce(dir * force, ForceMode2D.Force);
                break;
        }

    }
    
}
