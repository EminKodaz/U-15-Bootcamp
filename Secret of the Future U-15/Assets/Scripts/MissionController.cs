using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionController : MonoBehaviour
{
    [SerializeField] private bool comploted = false;
    [SerializeField] private Animator m_policeAnim;
    [SerializeField] private AudioSource TalkSound;

    [SerializeField] private bool isPolice;
    [SerializeField] private bool isPaper;
    [SerializeField] private GameObject PressText;
    [SerializeField] private GameObject p_TalkText;
    [SerializeField] private GameObject W_TalkText;
    [SerializeField] GameObject paper;
    [SerializeField] GameObject m_paperworld;
    [SerializeField] GameObject m_worldpaper;
    [SerializeField] GameObject Collider;
    [SerializeField] GameObject PlayerTalk;

    [SerializeField] GameObject RoomR;
    [SerializeField] GameObject RoomL;


    bool open;
    bool activePaper = false;

    private void Start()
    {
        if (paper != null)
        {
            paper.SetActive(false);
        }

        if (p_TalkText != null)
        {
            p_TalkText.SetActive(false);
        }

        if (W_TalkText != null)
        {
            W_TalkText.SetActive(false);
        }

        if (PlayerTalk != null)
        {
            PlayerTalk.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && activePaper)
        {
            open = !open;
            paper.SetActive(open);
            m_paperworld.SetActive(!open);
            m_worldpaper.SetActive(!open);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && comploted)
        {
            comploted = false;
            m_policeAnim.SetBool("trigger",true);

            //talk
            p_TalkText.SetActive(true);
        }

        if (other.gameObject.CompareTag("Player") && isPolice)
        {
            isPolice = false;
            m_policeAnim.SetBool("trigger", true);
            //talk
            W_TalkText.SetActive(true);

            Collider.SetActive(false);
        }

        if (other.gameObject.CompareTag("Player") && isPaper)
        {
            isPaper = false;
            PressText.gameObject.SetActive(true);
            activePaper = true;
            StartCoroutine(TimeMachineUSe());
            RoomR.SetActive(false);
            RoomL.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isPaper)
        {
            PressText.SetActive(false);
            paper.SetActive(false);
            activePaper = false;
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            if (p_TalkText != null)
            {
                p_TalkText.SetActive(false);
            }

            if (W_TalkText != null)
            {
                W_TalkText.SetActive(false);
            }
        }
    }

    IEnumerator TimeMachineUSe()
    {
        yield return new WaitForSeconds(5);
        PlayerTalk.SetActive(true);

    }
}
