using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossSysterm : FSMSystem
{
    public Boss_IdleState idleState;
    public Boss_AttackState attackState;
    public Boss_WalkState walkState;
    public Boss_deadState deadState;
    public Boss_Hurtstate hurtstate;
    public Boss_Winstate winstate;
    public Boss_JumpAttackstate jumpAttackstate;
    public Boss_StrikeState strikeState;
    //public List<Transform> lsTargets = new List<Transform>();
    //public int Index = 0;
    public Transform Target;

    public PolyNavAgent agent;
    public BossDataBinding bossDataBinding;

    public Transform transplayer;

    public BossUI BossUI;
    public string bossname;
    public int BossHP;

    public GameObject goFireBall;
    public GameObject goBlast;
    public Transform transFire;

    public Transform TransDefaultBoss;
    public int countBlast = 0;
    public float distanceFlyAttack = 5f;
    internal bool isPlayer = false;


    public override void OnSystemStart()
    {
        agent = GetComponent<PolyNavAgent>();
        bossDataBinding = GetComponent<BossDataBinding>();

        idleState.parent = this;
        AddState(idleState);

        walkState.parent = this;
        AddState(walkState);

        attackState.parent = this;
        AddState(attackState);

        jumpAttackstate.parent = this;
        AddState(jumpAttackstate);

        strikeState.parent = this;
        AddState(strikeState);

        //deadState.parent = this;
        //AddState(deadState);

        //hurtstate.parent = this;
        //AddState(hurtstate);

        //winstate.parent = this;
        //AddState(winstate);

        //Target = lsTargets[Index];
        base.OnSystemStart();
        BossUI.OnSetup(BossHP,bossname);
    }
    public override void OnSetup()
    {
        //curHP = maxHP;
        BossUI.OnSetup(BossHP, bossname);
        transform.position = TransDefaultBoss.position;
        GotoState(idleState);
        base.OnSetup();
    }
    public float GetDistance()
    {
        return Vector2.Distance(transform.position, transplayer.position);
    }

    public void BossAttack()
    {
        Debug.Log("Attack");
        GameObject goFireClone = Instantiate(goFireBall, transFire, false);
        goFireBall.transform.localPosition = Vector3.zero;
    }
    public void BossjumpAttack()
    {
        if (countBlast <= 1)
        {
            
            Target = transplayer;
            GotoState(jumpAttackstate);

        }
        else
        {
            //chuyen state strike
            transform.DOMoveY(transplayer.position.y + 1, 1f);
            transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            GotoState(strikeState);
        }
    }
    public void Blast()
    {
        GameObject goBlastclone = Instantiate(goBlast);
        goBlastclone.transform.position = transFire.position;

        Vector3 offset = transform.position - transplayer.position;
        float rotation = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        goBlastclone.transform.rotation = Quaternion.Euler(0f, 0f, rotation);

        goBlastclone.GetComponent<Blast>().OnSetup(transplayer);
    }

    public void ChangeToAttackState()
    {
        GotoState(attackState);
        transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
    }
    
}
