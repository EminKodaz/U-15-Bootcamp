using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondMissionManager : MonoBehaviour
{
    public Animator dadAnim;
    public GameObject Rifle;
    [SerializeField] private Transform InstateRiflePosition;
    [SerializeField] private Transform[] ZombieInstatePos;
    [SerializeField] private BoxCollider Collider;
    [SerializeField] private GameObject[] Zombie;
    [SerializeField] private Text TalkText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GameManager.instance.MissionSecond == false && GameManager.instance.MissionFirst == true)
        {
            GameManager.instance.isFollowingDad = true;
            if (dadAnim != null && Rifle != null && InstateRiflePosition != null)
            {
                dadAnim.SetBool("Sit", true);
                Instantiate(Rifle, InstateRiflePosition);

                //Talk
                TalkText.gameObject.SetActive(true);
            }
            GameManager.instance.MissionSecond = true;
        }

        if (other.gameObject.CompareTag("Player") && GameManager.instance.MissionFirst == false)
        {
            GameManager.instance.MissionFirst = true;
            Collider.enabled = false;
            Instantiate(Zombie[0] , ZombieInstatePos[0].position , Quaternion.identity);
            Instantiate(Zombie[1] , ZombieInstatePos[1].position, Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (TalkText != null)
        {
            TalkText.gameObject.SetActive(false);
        }
    }
}
