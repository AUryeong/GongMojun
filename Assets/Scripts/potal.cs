using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class potal : MonoBehaviour
{
    GameObject player;
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
  
   
         void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject == player)
            {
            SceneManager.LoadScene("Stage_1");  
            }
        }
    }

