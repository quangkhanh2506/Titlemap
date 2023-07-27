using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public float speed = 2f;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        StartCoroutine(DestroySelf(2f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("Destroy");
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(DestroySelf(0.1f));
        }
    }

    IEnumerator DestroySelf(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
