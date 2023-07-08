using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class ZombieAtacker : MonoBehaviour
{

    public Animator animator;
    ZombieAI zombieAI;
    public float radius;
    public float Attackradius;
    Vector3 AttackOverPos;
    public float AttackOverOffset;
    public GameObject AttackPos;
    public float speed;

    void Start()
    {
        zombieAI = GetComponent<ZombieAI>();
    }

    // Update is called once per frame
    void Update()
    {
        AttackOverPos = new Vector3(transform.position.x,transform.position.y + AttackOverOffset, transform.position.z);
        Collider[] solider = Physics.OverlapSphere(transform.position, radius);
        foreach (var player in solider)
        {
            // player.damage
            if (player.CompareTag("Player"))
            {
                animator.SetBool("Attack", true);
                ZombieAttack();
                zombieAI.agent.speed = 0;

            }
            else
            {
                animator.SetBool("Attack", false);
                zombieAI.agent.speed = speed;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(AttackOverPos, radius);
        Gizmos.DrawWireSphere(AttackPos.transform.position, Attackradius);
    }
    public void ZombieAttack()
    {
        Collider[] ZombiesAttack = Physics.OverlapSphere(AttackPos.transform.position, Attackradius);
        foreach (var zombi in ZombiesAttack)
        {
            PlayerHealthManager solider = zombi.GetComponentInChildren<PlayerHealthManager>();
            if (solider != null)
            {
                solider.TakeDamage(.5f);
            }
        }

    }
}
