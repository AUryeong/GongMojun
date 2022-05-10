using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wind : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private Enemy enemy;
    

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        enemy = GetComponent<Enemy>();
    }
    private void Start()
    {
        //Object[] A = GameObject.FindObjectsOfType(typeof(Obj));
    }
    private void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    public void playerWind(EWindType WindType, Vector2 dir, float playerdefense, float playerdmg, float enemystat, float force = 1)//바람의 종류, 방량, 힘
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
        //    {player.dmg - (player.dmg / 4), 0, playerdmg, playerdmg}[index];

        //e_stat = new float[]
        //{ enemy.defense + (enemy.defense / 4), 0, enemy.defense, enemy.defense }[index];


        //switch (WindType)//강풍과 돌풍은 추가예정
        //{
        //    case WindType.Contrarywind://역풍
        //        rb.AddForce(dir * force, ForceMode2D.Force);
        //        player.defense = p_defense;
        //        player.dmg = dmg;
        //        enemy.defense = e_stat;
        //        //현재 플레이어의 방어력 + (현재 플레이어의 방어력/2)
        //        break;
        //    case ewindtype.fairwind://순풍
        //        rb.AddForce(dir * force, ForceMode2D.Force);
        //        player.defense = p_defense;
        //        player.dmg = dmg;
        //        enemy.dmg = e_stat;

        //        break;
        //    case ewindtype.sirocco://열풍
        //        rb.AddForce(dir * force, ForceMode2D.Force);

        //        break;
        //    case ewindtype.coldwind://냉풍
        //        rb.AddForce(dir * force, ForceMode2D.Force);

        //        break;
        //}

    }
    public void EnemyWind()
    {

    }
}
