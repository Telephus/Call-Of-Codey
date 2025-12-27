using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class EnemyAI : MonoBehaviour 
{
    public Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {  
       agent.SetDestination(target.position);
    }
}
