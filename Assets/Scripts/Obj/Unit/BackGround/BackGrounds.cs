using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGrounds : MonoBehaviour
{
    public float offset;
    public float speed;
   private MeshRenderer renderer;
   void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    
    void Update()
    {
        offset += Time.deltaTime * speed;
        renderer.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
