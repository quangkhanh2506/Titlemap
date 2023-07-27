using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Blast : MonoBehaviour
{
    public float timer = 0.5f;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnSetup(Transform target)
    {
        transform.DOMove(target.position, timer, false).OnComplete(()=> 
        {
        //    animator.SetTrigger("Destroy");
            StartCoroutine(DestroySelf(0));
        });
    }
   

    IEnumerator DestroySelf(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            animator.SetTrigger("Destroy");
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(DestroySelf(0.1f));
            GameManager.Instance.PlayerHurt();
        }
    }
    public void DestroyBlast()
    {
        animator.SetTrigger("Destroy");
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(DestroySelf(0.1f));
    }
}
