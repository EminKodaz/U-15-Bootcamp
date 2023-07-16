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
    [SerializeField] private Text PressText;
    [SerializeField] private Text p_TalkText;
    [SerializeField] private Text W_TalkText;
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
            p_TalkText.gameObject.SetActive(false);
        }

        if (W_TalkText != null)
        {
            W_TalkText.gameObject.SetActive(false);
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
            p_TalkText.gameObject.SetActive(true);
        }

        if (other.gameObject.CompareTag("Player") && isPolice)
        {
            isPolice = false;
            m_policeAnim.SetBool("trigger", true);
            //talk
            W_TalkText.gameObject.SetActive(true);

            Collider.SetActive(false);
        }

        if (other.gameObject.CompareTag("Player") && isPaper)
        {
            isPaper = false;
            PressText.gameObject.SetActive(true);
            activePaper = true;
            PlayerTalk.SetActive(true);
            RoomR.SetActive(false);
            RoomL.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isPaper)
        {
            PressText.gameObject.SetActive(false);
            paper.SetActive(false);
            activePaper = false;
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            if (p_TalkText != null)
            {
                p_TalkText.gameObject.SetActive(false);
            }

            if (W_TalkText != null)
            {
                W_TalkText.gameObject.SetActive(false);
            }
        }
    }
}
