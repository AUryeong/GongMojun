using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EWindType
{
    Contrarywind = 1,//¿ªÇ³
    Fairwind,//¼øÇ³
    Sirocco,//¿­Ç³
    Coldwind,//³ÃÇ³
    Gale,//°­Ç³
    Squall//µ¹Ç³
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

    public void Wind(EWindType WindType, Vector2 dir, float playerdefense, float playerdmg, float enemystat, float force = 1)//¹Ù¶÷ÀÇ Á¾·ù, ¹æ·®, Èû
    {
        float p_defense = playerdefense;//ÃÊ±â°ª ÀúÀå
        float Dmg = playerdmg;
        float e_stat = enemystat;

        int index = (int)WindType - 1;

        p_defense = new float[4]
        { player.defense + (player.defense / 2),player.defense - (player.defense / 2) , playerdefense, playerdefense }[index];
        Dmg = new float[4]
            {player.Dmg - (player.Dmg / 4), 0, playerdmg, playerdmg}[index];
        e_stat = new float[] { enemy.defense + (enemy.defense / 4), 0, enemy.defense, enemy.defense }[index];
        

        switch (WindType)//°­Ç³°ú µ¹Ç³Àº Ãß°¡¿¹Á¤
        {
            case EWindType.Contrarywind://¿ªÇ³
                rb.AddForce(dir * force, ForceMode2D.Force);
                player.defense = p_defense;
                player.Dmg = Dmg;
                enemy.defense = e_stat;
                //ÇöÀç ÇÃ·¹ÀÌ¾îÀÇ ¹æ¾î·Â + (ÇöÀç ÇÃ·¹ÀÌ¾îÀÇ ¹æ¾î·Â/2)
                break;
            case EWindType.Fairwind://¼øÇ³
                rb.AddForce(dir * force, ForceMode2D.Force);
                player.defense = p_defense;
                player.Dmg = Dmg;
                enemy.Dmg = e_stat; 
                break;
            case EWindType.Sirocco://¿­Ç³
                rb.AddForce(dir * force, ForceMode2D.Force);
                break;
            case EWindType.Coldwind://³ÃÇ³
                rb.AddForce(dir * force, ForceMode2D.Force);
                break;
        }

    }
}
