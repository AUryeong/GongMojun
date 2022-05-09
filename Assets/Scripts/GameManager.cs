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

public class GameManager : MonoBehaviour
{
    public List<EWindType> eWindTypes = new List<EWindType>();


    private Rigidbody2D rb;
    [SerializeField]
    private GameObject player;
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
        
        enemy = GetComponent<Enemy>();
    }

    public void Wind(EWindType WindType, Vector2 dir, float playerdefense, float playerdmg, float enemystat, float force = 1)//바람의 종류, 방량, 힘
    {
        float p_defense = playerdefense;//초기값 저장
        float dmg = playerdmg;
        float e_stat = enemystat;
        //인덱스를 열거형을 int형으로 형변환해 사용
        int index = (int)WindType - 1;


        //float형 배열의 인덱스를 위에서 형변환한 int형 사용

        //p_defense = new float[4]
        //{ player.defense + (player.defense / 2),player.defense - (player.defense / 2) , playerdefense, playerdefense }[index];

        //dmg = new float[4]
        //    {player.Dmg - (player.Dmg / 4), 0, playerdmg, playerdmg}[index];

        //e_stat = new float[]
        //{ enemy.defense + (enemy.defense / 4), 0, enemy.defense, enemy.defense }[index];


        //switch (WindType)//강풍과 돌풍은 추가예정
        //{
        //    case EWindType.Contrarywind://역풍
        //        rb.AddForce(dir * force, ForceMode2D.Force);
        //        player.defense = p_defense;
        //        player.Dmg = dmg;
        //        enemy.defense = e_stat;
        //        //현재 플레이어의 방어력 + (현재 플레이어의 방어력/2)
        //        break;
        //    case EWindType.Fairwind://순풍
        //        rb.AddForce(dir * force, ForceMode2D.Force);
        //        player.defense = p_defense;
        //        player.Dmg = dmg;
        //        enemy.Dmg = e_stat;

        //        break;
        //    case EWindType.Sirocco://열풍
        //        rb.AddForce(dir * force, ForceMode2D.Force);

        //        break;
        //    case EWindType.Coldwind://냉풍
        //        rb.AddForce(dir * force, ForceMode2D.Force);

        //        break;
        //}

    }
}
