using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    public void Wind()
    {
        
    }
}