using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class ZombieAI : MonoBehaviour
{
    public float radius = 10f;
    public float Soundradius = 20f;
    public NavMeshAgent agent;
    private Animator animator;
    public Transform target;
    bool atackStart = false;
    [SerializeField] private bool ZombiMod;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (ZombiMod == false)
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

            Collider[] soliders = Physics.OverlapSphere(transform.position, Soundradius);
            bool foundPlayer = false;
            foreach (var player in soliders)
            {
                // player.damage
                if (player.CompareTag("Player") && player.GetComponentInChildren<WeaponManager>().fire)
                {
                    animator.SetBool("Scream", true);
                    atackStart = true;
                    foundPlayer = true;
                    agent.enabled = true;
                    break;
                }
                else if (player.CompareTag("Player"))
                {
                    foundPlayer = true;
                    agent.enabled = true;
                    SetRandomDestination();
                    break;
                }
            }

            if (!foundPlayer && !atackStart)
            {
                agent.enabled = false;
            }

            if (atackStart)
            {
                StartCoroutine(ScreamTime());
            }

           
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;

            if (agent.isActiveAndEnabled)
            {
                NavMeshHit hit;
                NavMesh.SamplePosition(target.position, out hit, 10f, NavMesh.AllAreas);
                Vector3 finalPosition = hit.position;
                agent.SetDestination(finalPosition);
            }
            atackStart = true;
        }


        if (agent.velocity.x == 0 && agent.velocity.y == 0 && agent.velocity.z == 0)
        {
            if (atackStart)
            {
                animator.SetBool("Run", false);
            }
            else
            {
                animator.SetBool("walk", false);
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
        if (!ZombiMod)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, radius);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, Soundradius);
        }
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