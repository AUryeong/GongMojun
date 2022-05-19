using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stage_1_Potal : MonoBehaviour
{
    GameObject player;
    bool Trigger;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Trigger = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Trigger == true) {
            SceneManager.LoadScene("Tutorial");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player")) Trigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player")) Trigger = false;
    }
}
