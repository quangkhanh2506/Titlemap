using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Emery_attack : FSMState
{
    [NonSerialized]
    public EmerySystem parent;

    private float timer = 1;

    public override void OnEnter()
    {
        
        timer = 1;
        parent.agent.Stop();
        parent.animator.SetTrigger("Attack");
        base.OnEnter();
    }

    public override void OnEnter(object data)
    {
        
        timer = 3;
        parent.animator.SetTrigger("Attack");
        Transform target = (Transform)data;
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
        parent.agent.SetDestination(target.position);
        parent.agent.maxSpeed = 10;
        base.OnEnter(data);
    }
    public override void OnUpdate()
    {  
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            parent.GotoState(parent.emery_Idle);
        }
        base.OnUpdate();
    }
    public override void OnExit()
    {
        parent.agent.maxSpeed = 3.5f;
        parent.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
        base.OnExit();
    }
}
