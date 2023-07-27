using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_check : MonoBehaviour
{
    private BossSysterm parent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("check");
            transform.parent.GetComponent<BossSysterm>().BossjumpAttack();
        }

    }
}
