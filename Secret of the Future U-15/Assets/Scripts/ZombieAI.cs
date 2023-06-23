using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class ZombieAI : MonoBehaviour
{
    public GameObject target;
    public Transform player;
    public bool triggered = false;
    NavMeshAgent agent;
    Animator animator;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (triggered)
        {
            transform.LookAt(target.gameObject.transform);
            agent.destination = player.position;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Scream", true);
            animator.SetBool("Run", true);
            Debug.Log("Sa");


        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = true;
            animator.SetBool("Attack", false);
            animator.SetBool("Scream", false);
        }
    }

}