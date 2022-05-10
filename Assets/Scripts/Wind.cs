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
        #region 바람 방향바꾸기
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

        #region 바람종류 바꾸기 키입력
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
    public void PlayerWind(int WindType, Vector2 dir, float playerdefense, float playerdmg, float force = 1)//바람의 종류, 방량, 힘
    {
        float p_defense = playerdefense;//초기값 저장
        float dmg = playerdmg;

        //인덱스를 열거형을 int형으로 형변환해 사용
        int index = WindType - 1;

        //float형 배열의 인덱스를 위에서 형변환한 int형 사용

        p_defense = new float[4]
        { player.defense + (player.defense / 2),player.defense - (player.defense / 2) , playerdefense, playerdefense }[index];

        dmg = new float[4]
            {player.dmg - (player.dmg / 2), player.dmg + (player.dmg / 2), playerdmg, playerdmg}[index];



        switch (WindType)//강풍과 돌풍은 추가예정
        {
            case 1:// 역풍
                rb.AddForce(dir * force, ForceMode2D.Force);
                player.defense = p_defense;
                player.dmg = dmg;
                //현재 플레이어의 방어력 + (현재 플레이어의 방어력/2)
                break;
            case 2://순풍
                rb.AddForce(dir * force, ForceMode2D.Force);
                player.defense = p_defense;
                player.dmg = dmg;
                break;
            case 3://열풍
                rb.AddForce(dir * force, ForceMode2D.Force);
                break;
            case 4://냉풍
                rb.AddForce(dir * force, ForceMode2D.Force);
                break;
        }


    }
    public void EnemyWind()
    {

    }
}
