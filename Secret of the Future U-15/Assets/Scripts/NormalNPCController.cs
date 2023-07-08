using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalNPCController : MonoBehaviour
{
    public Transform playerTransform;
    public float npcMoveSpeed = 2f;
    Animator animator;


    private bool isFollowingPlayer = false;
    void Start()
    {
        animator = GetComponent<Animator>();
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
            transform.Translate(Vector3.forward * npcMoveSpeed * 0);
        }

    }

    void Talk()
    {

    }

    void FollowPlayer()
    {
        transform.LookAt(playerTransform);
        transform.Translate(Vector3.forward * npcMoveSpeed * Time.deltaTime);  
    }

    IEnumerator TalkDelay()
    {

        yield return new WaitForSeconds(3f);
        isFollowingPlayer = true;
    }

}
