using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public float health = 100f;
    public Animator animator;
    ZombieAI zombieAI;
    NavMeshAgent agent;

    private void Start()
    {
        zombieAI = GetComponent<ZombieAI>();
        agent = GetComponent<NavMeshAgent>();
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
        GameManager.instance.KillCalculate(1);
    }
}
