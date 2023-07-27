using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerdataBinding : MonoBehaviour
{
    private Animator animator;
    

    private float speed;

    public float Speed {
        set
        {
            speed = value;
            animator.SetFloat("speed", speed);
        }
    }
    private bool attack;
    public bool Attack {
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


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
