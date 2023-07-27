using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class RedState : FSMState
{
    [NonSerialized]
    public TrafficLightSysterm parent;
    private float timer;
    // Start is called before the first frame update
    public override void OnEnter()
    {
        timer = 3;
        parent.imgLight.color = Color.red;
        base.OnEnter();
    }
    public override void OnEnter(object data)
    {
        timer = (float)data;
        parent.imgLight.color = Color.red;
        base.OnEnter(data);
    }
    public override void OnUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            // go to red state
            parent.GotoState(parent.greenState);
        }
        base.OnUpdate();
    }
}
