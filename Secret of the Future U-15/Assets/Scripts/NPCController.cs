using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    [SerializeField] private Animator NPCanim;
    [SerializeField] private NavMeshAgent NPCagent;
    [SerializeField] private Transform m_target_First;
    [SerializeField] private Transform m_target_Second;
    // Start is called before the first frame update
    void Start()
    {
        NPCanim = GetComponent<Animator>();
        NPCagent = GetComponent<NavMeshAgent>();

        NPCagent.SetDestination(m_target_First.position);
    }

    private void FixedUpdate()
    {
        float distanceFirsObject = Vector3.Distance(transform.position, m_target_First.transform.position);
        float distanceSecondObject = Vector3.Distance(transform.position, m_target_Second.transform.position);

        if (distanceFirsObject < 1)
        {
            NPCagent.SetDestination(m_target_Second.position);
        }

        if (distanceSecondObject < 1)
        {
            NPCagent.SetDestination(m_target_First.position);
        }

    }


}
