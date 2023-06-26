using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class ZombieAI : MonoBehaviour
{
    public float radius = 10f;
    public NavMeshAgent agent;
    private Animator animator;
    private Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Collider[] solider = Physics.OverlapSphere(transform.position, radius);
        foreach (var player in solider)
        {
            // player.damage
            if (player.CompareTag("Player"))
            {
                animator.SetBool("Scream", true);
                StartCoroutine(ScreamTime(player));
            }
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
    //animator.SetBool("Scream", true);
    //animator.SetBool("Attack", false);
    //animator.SetBool("Scream", false);
    //animator.SetBool("Run", true);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    IEnumerator ScreamTime(Collider player)
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("Scream", false);
        if (agent.isActiveAndEnabled)
        {
            agent.SetDestination(player.transform.position);
        }
    }

}