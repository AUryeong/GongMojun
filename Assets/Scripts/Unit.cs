using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Obj
{
    [Header("스탯")] //바람의 영향을 받는다
    public float dmg;
    public float atspd;
    public float dfs;
    public float spd;
    public float jumpSpeed;
    public float gvScale;
   


    [Space(20f)]
    [Header("플레이어 기본 스탯")]//바람의 영향을 받지 않고 장신구 같은 착용스탯의 영향을 받는다
    public float defaultDmg;
    public float defaultAtspd;
    public float defaultDfs;
    public float defaultSpd;
    public float defaultGvScale;
    public float maxStamina;
    public float currentStamina;
}
