using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Emery_die : FSMState
{
    [NonSerialized]
    public EmerySystem parent;
    public override void OnEnter()
    {
        parent.animator.SetTrigger("Die");
        parent.transform.GetComponent<Rigidbody2D>().gravityScale = 10;
        base.OnEnter();
    }
}
