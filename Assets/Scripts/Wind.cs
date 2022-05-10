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
public enum EWindDir
{
    Right = 1,
    Left = -1
}





public class Wind : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private Enemy enemy;
    private int intwindtype = (int)EWindType.Contrarywind;
    private Vector2 dir;
    private bool isdir;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        enemy = GetComponent<Enemy>();
    }
    private void Start()
    {
    }
    private void FixedUpdate()
    {
        #region �ٶ� ����ٲٱ�
        if (Input.GetKeyDown(KeyCode.Space) && isdir == true)
        {
            dir = new Vector2((int)EWindDir.Right, 0);
            isdir = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isdir == false)
        {
            dir = new Vector2((int)EWindDir.Left, 0);
            isdir = true;
        }
        #endregion

        #region �ٶ����� �ٲٱ� Ű�Է�
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            intwindtype = (int)EWindType.Contrarywind;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            intwindtype = (int)EWindType.Fairwind;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            intwindtype = (int)EWindType.Sirocco;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            intwindtype = (int)EWindType.Coldwind;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            intwindtype = (int)EWindType.Gale;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            intwindtype = (int)EWindType.Squall;
        }
        #endregion
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.CompareTag("Enemy"))
        {
            PlayerWind(intwindtype, dir, player.defense, player.dmg);
            EnemyWind();
        }
    }
    public void PlayerWind(int WindType, Vector2 dir, float playerdefense, float playerdmg, float force = 1)//�ٶ��� ����, �淮, ��
    {
        float p_defense = playerdefense;//�ʱⰪ ����
        float dmg = playerdmg;

        //�ε����� �������� int������ ����ȯ�� ���
        int index = WindType - 1;

        //float�� �迭�� �ε����� ������ ����ȯ�� int�� ���

        p_defense = new float[4]
        { player.defense + (player.defense / 2),player.defense - (player.defense / 2) , playerdefense, playerdefense }[index];

        dmg = new float[4]
            {player.dmg - (player.dmg / 2), player.dmg + (player.dmg / 2), playerdmg, playerdmg}[index];



        switch (WindType)//��ǳ�� ��ǳ�� �߰�����
        {
            case 1:// ��ǳ
                rb.AddForce(dir * force, ForceMode2D.Force);
                player.defense = p_defense;
                player.dmg = dmg;
                //���� �÷��̾��� ���� + (���� �÷��̾��� ����/2)
                break;
            case 2://��ǳ
                rb.AddForce(dir * force, ForceMode2D.Force);
                player.defense = p_defense;
                player.dmg = dmg;
                break;
            case 3://��ǳ
                rb.AddForce(dir * force, ForceMode2D.Force);
                break;
            case 4://��ǳ
                rb.AddForce(dir * force, ForceMode2D.Force);
                break;
        }


    }
    public void EnemyWind()
    {

    }
}
