using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

[Serializable]
public class Boss_JumpAttackstate : FSMState
{
    [NonSerialized]
    public BossSysterm parent;
    private float timer;
    public override void OnEnter()
    {
       
        parent.bossDataBinding.Jump = true;
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
        if (parent.countBlast == 0)
        {
            timer = 100f;
            parent.transform.DOMoveY(parent.transform.position.y + 2, 1f).OnComplete(() =>
            {
                
                parent.BossjumpAttack();
            });
        }
        else
        {
            timer = 1;
        }
        
        parent.countBlast++;
        Debug.Log("CountBlast: " + parent.countBlast);
        base.OnEnter();
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            parent.BossjumpAttack();
        }
    }
    public override void OnExit()
    {
        parent.Blast();
        base.OnExit();
    }
}
