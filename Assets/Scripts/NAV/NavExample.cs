using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavExample : MonoBehaviour
{
    public PolyNavAgent agent;
    public Transform target;
    public List<Transform> lsTarget = new List<Transform>();
    private int index = 0;
    public float distance = 0.35f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector2.Distance(agent.transform.position, target.position));
        if (Vector2.Distance(agent.transform.position, target.position) > distance)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            index++;
            index = index % lsTarget.Count;
            target = lsTarget[index];
        }
        
    }
}
