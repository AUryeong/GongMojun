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
    public void playerWind(EWindType WindType, Vector2 dir, float playerdefense, float playerdmg, float enemystat, float force = 1)//�ٶ��� ����, �淮, ��
    {
        float p_defense = playerdefense;//�ʱⰪ ����
        float dmg = playerdmg;
        float e_stat = enemystat;
        //�ε����� �������� int������ ����ȯ�� ���
        int index = (int)WindType - 1;


        //float�� �迭�� �ε����� ������ ����ȯ�� int�� ���

        //p_defense = new float[4]
        //{ player.defense + (player.defense / 2),player.defense - (player.defense / 2) , playerdefense, playerdefense }[index];

        //dmg = new float[4]
        //    {player.dmg - (player.dmg / 4), 0, playerdmg, playerdmg}[index];

        //e_stat = new float[]
        //{ enemy.defense + (enemy.defense / 4), 0, enemy.defense, enemy.defense }[index];


        //switch (WindType)//��ǳ�� ��ǳ�� �߰�����
        //{
        //    case WindType.Contrarywind://��ǳ
        //        rb.AddForce(dir * force, ForceMode2D.Force);
        //        player.defense = p_defense;
        //        player.dmg = dmg;
        //        enemy.defense = e_stat;
        //        //���� �÷��̾��� ���� + (���� �÷��̾��� ����/2)
        //        break;
        //    case ewindtype.fairwind://��ǳ
        //        rb.AddForce(dir * force, ForceMode2D.Force);
        //        player.defense = p_defense;
        //        player.dmg = dmg;
        //        enemy.dmg = e_stat;

        //        break;
        //    case ewindtype.sirocco://��ǳ
        //        rb.AddForce(dir * force, ForceMode2D.Force);

        //        break;
        //    case ewindtype.coldwind://��ǳ
        //        rb.AddForce(dir * force, ForceMode2D.Force);

        //        break;
        //}

    }
    public void EnemyWind()
    {

    }
}
