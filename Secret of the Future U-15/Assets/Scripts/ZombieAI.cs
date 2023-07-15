using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class ZombieAI : MonoBehaviour
{
    public NavMeshAgent agent;
    private Animator animator;
    public Transform target;
    [SerializeField] private float distance;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        distance = Vector3.Distance(transform.position , target.position);

        agent.SetDestination(target.position);

        if (distance < 0.5f)
        {
            agent.speed = 0;
        }

        if (agent.velocity.x == 0 && agent.velocity.y == 0 && agent.velocity.z == 0)
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }
    }

}