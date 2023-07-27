using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Boss_WalkState : FSMState
{
    [NonSerialized]
    public BossSysterm parent;
    private float distance = 1f;

    public override void OnEnter()
    {
        parent.agent.maxSpeed = 3.5f;
        parent.bossDataBinding.Speed = parent.agent.maxSpeed;
        
        Vector2 dir = parent.transform.position - parent.Target.position;
        dir.Normalize();
        Debug.Log(dir);
        if (dir.x > 0)
        {
            parent.transform.localScale = new Vector3(-Math.Abs(parent.transform.localScale.x), parent.transform.localScale.y);
        }
        else
        {
            parent.transform.localScale = new Vector3(Math.Abs(parent.transform.localScale.x), parent.transform.localScale.y);
        }
        
        base.OnEnter();
    }
    public override void OnUpdate()
    {

        if (Vector2.Distance(parent.agent.transform.position, parent.Target.position) >= distance)
        {
            parent.agent.SetDestination(parent.Target.position);
        }
        else
        {
            parent.GotoState(parent.idleState);
        }
        
        base.OnUpdate();
    }
    public override void OnExit()
    {
        parent.bossDataBinding.Speed = 0;
        base.OnExit();
    }
}
