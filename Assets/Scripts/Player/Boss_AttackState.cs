using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Boss_AttackState : FSMState
{
    [NonSerialized]
    public BossSysterm parent;
    private float timer = 1;
    public override void OnEnter()
    {
        timer = 1;
        parent.agent.Stop();
        parent.bossDataBinding.Attack = true;
        base.OnEnter();
    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {            
            parent.GotoState(parent.idleState);
        }
        base.OnUpdate();
    }


    public override void OnExit()
    {
        parent.agent.maxSpeed = 3.5f;
        
        base.OnExit();
    }

}
