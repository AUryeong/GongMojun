using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    GameObject player;

    public Font font { get; internal set; }
    public int fontSize { get; internal set; }
    public TextAnchor alignment { get; internal set; }
    public string text { get; internal set; }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player) {

            Destroy(gameObject);
        }
    }
}
