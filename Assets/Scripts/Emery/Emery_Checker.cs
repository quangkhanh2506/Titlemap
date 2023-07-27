using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emery_Checker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.parent.GetComponent<EmerySystem>().ChangeToAttackState(collision.gameObject);
        }

    }
}
