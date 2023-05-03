using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSystem : MonoBehaviour
{
    protected BasicStats Stats;

    protected virtual void StatSetting(int hp, int atk,float moveSpeed,float jumpForce)
    {
        Stats.HP = hp;
        Stats.ATK = atk;
        Stats.MoveSpeed = moveSpeed;
        Stats.JumpForce = jumpForce;
    }
    protected struct BasicStats
    {
        public int HP;
        public int ATK;
        public float MoveSpeed;
        public float JumpForce;
    }
}
