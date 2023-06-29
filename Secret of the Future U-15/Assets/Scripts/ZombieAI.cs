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
    public Transform target;
    bool atackStart = false;

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
                atackStart = true;
            }
        }

        if (atackStart)
        {
            StartCoroutine(ScreamTime());
        }
        else
        {

            SetRandomDestination(); // Yeni bir rastgele hedef belirle

        }

        if (agent.velocity.x == 0 && agent.velocity.y == 0 && agent.velocity.z == 0)
        {
            if (atackStart)
            {
                animator.SetBool("Run", false);
            }
            else
            {
                animator.SetBool("walk",false);
            }
        }
        else
        {
            if (atackStart)
            {
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("walk", true);
            }
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

    IEnumerator ScreamTime()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("Scream", false);
        if (agent.isActiveAndEnabled)
        {
            NavMeshHit hit;
            NavMesh.SamplePosition(target.position, out hit, 10f, NavMesh.AllAreas);
            Vector3 finalPosition = hit.position;
            agent.SetDestination(finalPosition);
        }
    }

    private void SetRandomDestination()
    {
        Vector3 randomPoint = Random.insideUnitSphere * 10f; // Rastgele bir nokta oluþtur
        NavMeshHit hit;
        NavMesh.SamplePosition(transform.position + randomPoint, out hit, 10f, NavMesh.AllAreas); // O noktanýn geçerli bir NavMesh alaný içinde olduðunu kontrol et
        Vector3 finalPosition = hit.position;
        agent.SetDestination(finalPosition); // NPC'nin hedefi olarak rastgele noktayý ayarla
    }

}