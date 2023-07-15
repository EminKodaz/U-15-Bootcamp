using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NormalNPCController : MonoBehaviour
{
    public Transform playerTransform;
    public Transform DadTransform;
    Animator animator;
    NavMeshAgent agent;
    bool dad;
    public GameObject MissionText;
    public GameObject ZombieAttackManager;

    private bool isFollowingPlayer = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        ZombieAttackManager.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.isFollowingDad == true)
        {
            ChangeTarget();
        }

        if (Vector3.Distance(transform.position, playerTransform.position) < 3f && !dad && GameManager.instance.MissionFirst == true)
        {
            Talk();
            animator.SetBool("playerIsHere", true);
            StartCoroutine(TalkDelay());
            ZombieAttackManager.SetActive(true);
        }
        else if (Vector3.Distance(transform.position, playerTransform.position) < 3f && !dad && GameManager.instance.MissionFirst == false)
        {
            MissionText.SetActive(true);
        }
        else
        {
            MissionText.SetActive(false);
        }

        if (Vector3.Distance(transform.position, playerTransform.position) < 1.5f)
        {
            isFollowingPlayer = false;
        }




        if (isFollowingPlayer && !dad)
        {
            isFollowingPlayer = true;
            FollowPlayer();

        }

        if (agent.velocity.x == 0 && agent.velocity.y == 0 && agent.velocity.z == 0)
        {
            animator.SetBool("followPlayer", false);
        }
        else
        {
            animator.SetBool("followPlayer", true);
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

    public void ChangeTarget()
    {
        agent.SetDestination(DadTransform.position);
        dad = true;
        isFollowingPlayer = false;
    }

}
