using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Unit
{
    protected RaycastHit2D raycast;//�÷��̾ ������ ������
    protected Vector3 dir;//�÷��̾ ����,���� ����

    /// <summary>��������?</summary>
    protected bool isAttack;
    protected bool isAttacking;

    float time = 0;




    [SerializeField]
    protected float rayDistance;//������ �Ÿ�

    [SerializeField]
    protected float changeDirDel;//�Դ� ���� �Ÿ��� �ð�
    protected abstract void Attack();

    protected abstract void Move();

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && time >=Atspd)
        {
            time = 0;
            isAttacking = true;
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttacking = false;
        }
    }
    void FixedUpdate()
    {
        
        time = Time.deltaTime;
        Debug.DrawRay(Vector3.zero, dir, Color.red);
        raycast = Physics2D.Raycast(Vector3.zero, dir, 4, LayerMask.GetMask("Player"));

        //�������� �ƴ϶��
        if (!isAttack)
        {
            Move();
        }
        else if(isAttack && isAttacking)
        {
            Attack();
        }
        if (raycast)
        {
            isAttack = true;
        }
        else
        {
            isAttack = false;
        }
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
    public void GetAttack(Unit unit)
    {
        
    }
    
}
