using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wind : MonoBehaviour
{
    private Player player;
    private Enemy enemy;
    private void Awake()
    {
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
}
