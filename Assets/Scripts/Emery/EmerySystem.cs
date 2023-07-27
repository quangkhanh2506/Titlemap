using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmerySystem : FSMSystem
{
    public Emery_idle emery_Idle;
    public Emery_walk emery_Walk;
    public Emery_attack emery_Attack;
    public Emery_die emery_Die;

    public List<Transform> lsTarget = new List<Transform>();
    public Transform target;
    public int index = 0;

    public Animator animator;

    public PolyNavAgent agent;

    public override void OnSystemStart()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<PolyNavAgent>();

        emery_Idle.parent = this;
        AddState(emery_Idle);

        emery_Walk.parent = this;
        AddState(emery_Walk);

        emery_Attack.parent = this;
        AddState(emery_Attack);

        emery_Die.parent = this;
        AddState(emery_Die);

        target = lsTarget[index];
        
        base.OnSystemStart();
    }

    IEnumerator DestroySelf(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
    public void EneryDie()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        GotoState(emery_Die);
    }

    public void ChangeToAttackState()
    {
        GotoState(emery_Attack);
        transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
    }
    public void ChangeToAttackState(GameObject player)
    {
        GotoState(emery_Attack, player.transform);
        transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.PlayerHurt();
        }
    }
}
