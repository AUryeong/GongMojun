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
    public void Wind(EWindType WindType,Vector2 dir ,float force = 1)//¹Ù¶÷ÀÇ Á¾·ù, ¹æ·®, Èû
    {
        switch (WindType)//°­Ç³°ú µ¹Ç³Àº Ãß°¡¿¹Á¤
        {
            case EWindType.Contrarywind://¿ªÇ³
                rb.AddForce(dir * force,ForceMode2D.Force);
                break;
            case EWindType.Fairwind://¼øÇ³
                rb.AddForce(dir * force, ForceMode2D.Force);
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
