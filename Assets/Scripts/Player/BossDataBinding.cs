using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDataBinding : MonoBehaviour
{
    public Animator animator;


    private float speed;

    public float Speed
    {
        set
        {
            speed = value;
            animator.SetFloat("speed", speed);
        }
    }
    private bool attack;
    public bool Attack
    {
        set
        {
            attack = value;
            animator.SetTrigger("attack");
        }
    }
    private bool jump;
    public bool Jump
    {
        set
        {
            jump = value;
            animator.SetTrigger("jump");
        }
    }
    private bool win;
    public bool Win
    {
        set
        {
            win = value;
            animator.SetTrigger("win");
        }
    }
    private bool hurt;
    public bool Hurt
    {
        set
        {
            hurt = value;
            animator.SetTrigger("hurt");
        }
    }

  
    private bool strike;
    public bool Strike { set 
        { 
            strike = value;
            animator.SetTrigger("strike");
        } 
    }




    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
