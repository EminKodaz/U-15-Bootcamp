using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalNPCController : MonoBehaviour
{
    public Transform playerTransform;
    public float npcMoveSpeed = 2f;
    Animator animator;

    private FirstPersonController fpsController;


    private bool isFollowingPlayer = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        fpsController = FindObjectOfType<FirstPersonController>();  
    }

    // Update is called once per frame
    void Update()
    {
        float playerMoveSpeed = fpsController.MoveSpeed;
        if (Vector3.Distance(transform.position, playerTransform.position) < 2f)
        {
            Talk();
            isFollowingPlayer = true;
            animator.SetBool("playerIsHere", true);
        }

        if (isFollowingPlayer)
        {
            animator.SetBool("followPlayer", true);
            transform.LookAt(playerTransform); // NPC, oyuncuya doðru yöneliyor
            transform.Translate(Vector3.forward * npcMoveSpeed * Time.deltaTime); // NPC, oyuncuyu takip ediyor
        }

        // Oyuncu kýpýrdamadýðýnda NPC de kýpýrdamayý býrakýyor
        if (isFollowingPlayer && playerMoveSpeed < 0.1f)
        {
            animator.SetBool("followPlayer", false);
            isFollowingPlayer = false;
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

    private void OnTriggerEnter(Collider other)
    {
        if (isFollowingPlayer && other.gameObject.CompareTag("Player")) 
        {
            isFollowingPlayer = false;

        }
    }

}
