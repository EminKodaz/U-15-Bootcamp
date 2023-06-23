using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAtacker : MonoBehaviour
{

    public Animator animator;
    public ZombieAI zombieAI;
    public float radius;
    Vector3 AttackOverPos;
    public float AttackOverOffset;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        AttackOverPos = new Vector3(transform.position.x,transform.position.y + AttackOverOffset, transform.position.z);
        Collider[] solider = Physics.OverlapSphere(AttackOverPos, radius);
        foreach (var player in solider)
        {
            // player.damage
            if (player.CompareTag("Player"))
            {
                animator.SetBool("Attack", true);
                zombieAI.triggered = false;

            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(AttackOverPos, radius);
    }
}
