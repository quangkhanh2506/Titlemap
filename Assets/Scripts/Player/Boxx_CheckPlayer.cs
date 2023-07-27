using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxx_CheckPlayer : MonoBehaviour
{
    public BossSysterm Boss;
    //private float timer = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //timer -= Time.deltaTime;
        if (collision.tag == "Player")
        {
            //if (timer < 0)
            //{
            Debug.Log("Check player");
            Boss.GotoState(Boss.idleState);
            Boss.isPlayer = true;
            //}
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
