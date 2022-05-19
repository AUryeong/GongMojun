using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_Potal : MonoBehaviour
{
    
    GameObject player;
    bool Coll;
    BoxCollider2D collision;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Coll = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Coll == true) 
        {
            SceneManager.LoadScene("Stage_1");
        
        }
     

    }




    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Coll = true;
        }      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {

            Coll = false;
        }
    }
}

