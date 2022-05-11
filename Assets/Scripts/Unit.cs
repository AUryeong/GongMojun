using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Obj
{
    [Header("����")] //�ٶ��� ������ �޴´�
    public float dmg;
    public float atspd;
    public float dfs;
    public float spd;
    public float jumpSpeed;
    public float gvScale;
   


    [Space(20f)]
    [Header("�÷��̾� �⺻ ����")]//�ٶ��� ������ ���� �ʰ� ��ű� ���� ���뽺���� ������ �޴´�
    public float defaultDmg;
    public float defaultAtspd;
    public float defaultDfs;
    public float defaultSpd;
    public float defaultGvScale;
    public float maxStamina;
    public float currentStamina;
}
