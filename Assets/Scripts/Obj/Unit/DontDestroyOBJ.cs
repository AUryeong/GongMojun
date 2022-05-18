using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOBJ : MonoBehaviour
{
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        var obj = FindObjectsOfType<DontDestroyOBJ>();
        if (obj.Length == 1) { DontDestroyOnLoad(gameObject); }
        else
        {
            Destroy(gameObject);
        }
    }
}
       


