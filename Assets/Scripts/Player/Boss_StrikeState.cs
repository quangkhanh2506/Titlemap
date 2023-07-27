using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

[Serializable]
public class Boss_StrikeState : FSMState
{
    [NonSerialized]
    public BossSysterm parent;
    private Vector2 position_move;
    public override void OnEnter()
    {
        parent.bossDataBinding.Strike = true;
        parent.countBlast = 0;
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
        parent.agent.maxSpeed = 5;
        position_move = new Vector2(parent.transplayer.position.x - 2.5f, parent.transplayer.position.y);
        parent.agent.SetDestination(position_move);
        base.OnEnter();
    }
    public override void OnLateUpdate()
    {
        parent.GotoState(parent.idleState);
        parent.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
        base.OnLateUpdate();
    }
    //public override void OnExit()
    //{
    //    parent.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
    //    base.OnExit();
    //}
}
