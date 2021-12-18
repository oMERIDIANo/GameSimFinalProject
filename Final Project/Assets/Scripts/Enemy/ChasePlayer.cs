using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    GameObject target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent != null)
        {
            agent.SetDestination(target.transform.position);
        }
        
    }
}
