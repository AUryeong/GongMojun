using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandBack : MonoBehaviour
{
    [SerializeField]
    Text text;
    [SerializeField]
    Text text2;

    int score = 0;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider != null)
        {
            int jumsu = (int)(Mathf.Abs(coll.collider.GetComponent<Player>().LastX) + Mathf.Abs(coll.collider.GetComponent<Player>().LastY));
            if(score < jumsu)
            {
                score = jumsu;
                text.text = jumsu.ToString();
            }
            text2.text = jumsu.ToString();
        }
    }
}
