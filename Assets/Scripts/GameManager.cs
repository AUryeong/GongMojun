using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    //public List<EWindType> eWindTypes = new List<EWindType>();


    private Rigidbody2D rb;
    [SerializeField]
    private Player player;
    [SerializeField]
    private Enemy enemy;


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
