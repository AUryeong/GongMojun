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
    [Header("스탯")] //바람의 영향을 받는다
    [HideInInspector]
    public float Dmg;
    [HideInInspector]
    public float Atspd;
    [HideInInspector]
    public float Dfs;
    [HideInInspector]
    public float Spd;


    [Space(20f)]
    [Header("플레이어 기본 스탯")]//바람의 영향을 받지 않고 장신구 같은 착용스탯의 영향을 받는다
    public float defaultDmg;
    public float defaultAtspd;
    public float defaultDfs;
    public float defaultSpd;
    public float maxStamina;
    public float GravityScale;
    public float currentStamina;

}
