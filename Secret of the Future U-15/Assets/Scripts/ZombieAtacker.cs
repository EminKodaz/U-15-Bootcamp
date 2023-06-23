using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAtacker : MonoBehaviour
{

    public Animator animator;
    public ZombieAI zombieAI;
    
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Attack", true);
            zombieAI.triggered = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Attack", false);
            zombieAI.triggered = true;
        }
    }
}
