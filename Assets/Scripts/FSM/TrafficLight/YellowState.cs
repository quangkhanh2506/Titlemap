using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class YellowState : FSMState
{
    [NonSerialized]
    public TrafficLightSysterm parent;
    private float timer;

    public override void OnEnter()
    {
        base.OnEnter();
        timer = 3;
        parent.imgLight.color = Color.yellow;
    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            // go to red state
            parent.GotoState(parent.redState);
        }
        base.OnUpdate();
    }

}
