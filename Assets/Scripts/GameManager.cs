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

public class GameManager : MonoBehaviour
{
    
    //public List<EWindType> eWindTypes = new List<EWindType>();


    private Rigidbody2D rb;
    [SerializeField]
    private Player player;
    [SerializeField]
    private Enemy enemy;

    public EWindType eWindType;
    public EObjType eObjType;


    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }

    }
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        
        enemy = GetComponent<Enemy>();
    }

    
}
