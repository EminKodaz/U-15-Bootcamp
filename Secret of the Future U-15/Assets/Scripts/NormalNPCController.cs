using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalNPCController : MonoBehaviour
{
    public Transform playerTransform;
    Animator animator;
    NavMeshAgent agent;


    private bool isFollowingPlayer = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, playerTransform.position) < 3f)
        {
            Talk();
            animator.SetBool("playerIsHere", true);
            StartCoroutine(TalkDelay());
        }

        if (Vector3.Distance(transform.position, playerTransform.position) < 1.5f)
        {
            isFollowingPlayer = false;
        }




        if (isFollowingPlayer)
        {
            isFollowingPlayer = true;
            animator.SetBool("followPlayer", true);
            FollowPlayer();
        }

        if (!isFollowingPlayer)
        {

            isFollowingPlayer = false;
            animator.SetBool("followPlayer", false);
            //agent.SetDestination(transform.position);
        }

    }

    void Talk()
    {

    }

    void FollowPlayer()
    {
        transform.LookAt(playerTransform);
        agent.SetDestination(playerTransform.position);
    }

    IEnumerator TalkDelay()
    {

        yield return new WaitForSeconds(3f);
        isFollowingPlayer = true;
    }

}
