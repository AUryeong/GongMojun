using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Unit
{
    protected RaycastHit2D raycast;//�÷��̾ ������ ������
    protected Vector3 dir;//�÷��̾ ����,���� ����

    /// <summary>��������?</summary>
    protected bool isAttack;


    [SerializeField]
    protected float rayDistance;//������ �Ÿ�

    [SerializeField]
    protected float changeDirDel;//�Դ� ���� �Ÿ��� �ð�
    protected abstract void Attack();

    protected abstract void Move();
    
    void FixedUpdate()
    {
        Debug.DrawRay(Vector3.zero, dir, Color.red);

        //�������� �ƴ϶��
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
