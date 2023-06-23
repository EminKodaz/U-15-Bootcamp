using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDamage : MonoBehaviour
{
    public float health = 100f;
    public Animator animator;
    public ZombieAI zombieAI;
    public NavMeshAgent agent;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            animator.SetBool("isDead", true);
            agent.enabled = false;
            zombieAI.enabled = false;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
