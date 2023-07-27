using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Boss_IdleState : FSMState
{
    [NonSerialized]
    public BossSysterm parent;
    private float timer = 2;

    public override void OnEnter()
    {
        timer = 2;
        parent.bossDataBinding.Speed = 0;
        base.OnEnter();
    }
    public override void OnUpdate()
    {
        Debug.Log("Idle");
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (parent.isPlayer == true)
            {
                parent.BossjumpAttack();
            }
        }

        base.OnUpdate();
    }
    //public override void OnExit()
    //{
    //    parent.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
    //    base.OnExit();
    //}
}

