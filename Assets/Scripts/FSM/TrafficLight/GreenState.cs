using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class GreenState : FSMState
{
    [NonSerialized]
    public TrafficLightSysterm parent;
    private float timer;
    // Start is called before the first frame update
    public override void OnEnter()
    {
        timer = 3;
        parent.imgLight.color = Color.green;
        base.OnEnter();
    }

    public override void OnEnter(object data)
    {
        timer = (float)data;
        parent.imgLight.color = Color.green;
        base.OnEnter(data);
    }
    public override void OnUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            // go to red state
            parent.GotoState(parent.yellowState);
        }
        base.OnUpdate();
    }
}
