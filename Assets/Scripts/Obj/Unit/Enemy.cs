using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Unit
{
    protected RaycastHit2D raycast;//플레이어를 감지할 레이저
    protected Vector3 dir;//플레이어가 가는,보는 방향

    /// <summary>공격중임?</summary>
    protected bool isAttack;


    [SerializeField]
    protected float rayDistance;//레이저 거리

    [SerializeField]
    protected float changeDirDel;//왔다 갔다 거리는 시간
    protected abstract void Attack();

    protected abstract void Move();
    
    void FixedUpdate()
    {
        Debug.DrawRay(Vector3.zero, dir, Color.red);

        //공격중이 아니라면
        if (!isAttack)
        {
            Move();
        }
        else
        {
            Attack();
        }

        raycast = Physics2D.Raycast(Vector3.zero, dir, 4);
    }
    public void LRMove()
    {
        StartCoroutine(CMove());
    }
    private IEnumerator CMove()
    {
        
        if (dir == Vector3.right)
        {
            dir = Vector3.left;
            Rb.velocity = dir * Spd;
        }
        else
        {
            dir = Vector3.right;
            Rb.velocity = dir * Spd;
        }
        yield return new WaitForSeconds(changeDirDel);
    }
    public void GetAttack()
    {
        
    }
}
