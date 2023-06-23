using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class ZombieAI : MonoBehaviour
{
    public GameObject target;
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
            agent.destination = target.transform.position;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Scream", true);

            StartCoroutine(WaitRun());
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
    IEnumerator WaitRun()
    {
        yield return new WaitForSeconds(2.5f);

        animator.SetBool("Run", true);
    }

}