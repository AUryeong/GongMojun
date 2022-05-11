using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Right,
    Left,
    Up,
    Down
}
public class Unit : Obj
{
    protected virtual void Start()
    {
        Dmg = defaultDmg;
        Atspd = defaultAtspd;
        Dfs = defaultDfs;
        Spd = defaultSpd;
        GravityScale = rb.gravityScale;
    }
    public Direction direction;
    [Header("����")] //�ٶ��� ������ �޴´�
    [HideInInspector]
    public float Dmg;
    [HideInInspector]
    public float Atspd;
    [HideInInspector]
    public float Dfs;
    [HideInInspector]
    public float Spd;


    [Space(20f)]
    [Header("�÷��̾� �⺻ ����")]//�ٶ��� ������ ���� �ʰ� ��ű� ���� ���뽺���� ������ �޴´�
    public float defaultDmg;
    public float defaultAtspd;
    public float defaultDfs;
    public float defaultSpd;
    public float maxStamina;
    public float GravityScale;
    public float currentStamina;

}
