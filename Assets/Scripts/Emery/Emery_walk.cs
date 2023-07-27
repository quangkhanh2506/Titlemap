using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Emery_walk : FSMState
{
    [NonSerialized]
    public EmerySystem parent;
    private float distance = 0.35f;

    public override void OnEnter()
    {
        parent.animator.SetFloat("Speed", parent.agent.maxSpeed);
        
        Vector2 dir = parent.transform.position - parent.target.position;
        dir.Normalize();
        Debug.Log(dir);
        if (dir.x > 0)
        {
            parent.transform.localScale = new Vector3(Math.Abs(parent.transform.localScale.x), parent.transform.localScale.y);
        }
        else
        {
            parent.transform.localScale = new Vector3(-Math.Abs(parent.transform.localScale.x), parent.transform.localScale.y);
        }
        base.OnEnter();
    }
    public override void OnUpdate()
    {
        if(Vector2.Distance(parent.transform.position,parent.target.position) > distance)
        {
            parent.agent.SetDestination(parent.target.position);
        }
        else
        {
            parent.GotoState(parent.emery_Idle);
        }
        base.OnUpdate();
    }
    public override void OnExit()
    {
        parent.index++;
        parent.index = parent.index % parent.lsTarget.Count;
        parent.target = parent.lsTarget[parent.index];

        base.OnExit();
    }
}
