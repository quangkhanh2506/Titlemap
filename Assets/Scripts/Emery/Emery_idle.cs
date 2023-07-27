using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Emery_idle : FSMState
{
    [NonSerialized]
    public EmerySystem parent;
    private float timer = 1;

    public override void OnEnter()
    {
        timer = 1;
        parent.animator.SetFloat("Speed", 0);
        base.OnEnter();
    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            parent.GotoState(parent.emery_Walk);
        }
        base.OnUpdate();
    }
}
