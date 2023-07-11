using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMissionManager : MonoBehaviour
{
    public Animator dadAnim;
    public GameObject Rifle;
    [SerializeField] private Transform InstateRiflePosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GameManager.instance.MissionSecond == false && GameManager.instance.MissionFirst == true)
        {
            GameManager.instance.isFollowingDad = true;
            if (dadAnim != null && Rifle != null && InstateRiflePosition != null)
            {
                dadAnim.SetBool("Sit", true);
                Instantiate(Rifle, InstateRiflePosition);

            }
            GameManager.instance.MissionSecond = true;
        }

        if (other.gameObject.CompareTag("Player") && GameManager.instance.MissionFirst == false)
        {
            Debug.Log("görev start");
        }
    }
}
