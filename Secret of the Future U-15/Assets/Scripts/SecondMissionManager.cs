using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMissionManager : MonoBehaviour
{
    public Animator dadAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.isFollowingDad = true;
            dadAnim.SetBool("Sit",true);
        }
    }
}
