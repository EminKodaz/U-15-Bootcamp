using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDamage : MonoBehaviour
{
    public float health = 100f;
    public float radius;
    public Animator animator;
    public GameObject HeadPos;
    ZombieAI zombieAI;
    NavMeshAgent agent;

    private void Start()
    {
        zombieAI = GetComponent<ZombieAI>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Collider[] damage = Physics.OverlapSphere(HeadPos.transform.position, radius);


    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            agent.enabled = false;
            animator.SetBool("isDead", true);
            zombieAI.enabled = false;
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject,20f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(HeadPos.transform.position, radius);
    }
}
