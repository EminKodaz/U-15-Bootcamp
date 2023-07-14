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
    [SerializeField] private bool isRaper;
    [SerializeField] private Text PressText;
    [SerializeField] GameObject paper;
    [SerializeField] GameObject m_paperworld;
    [SerializeField] GameObject m_worldpaper;

    bool open;
    bool activePaper = false;

    private void Start()
    {
        if (paper != null)
        {
            paper.SetActive(false);
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
        if (other.gameObject.CompareTag("Player") && !comploted && isPolice)
        {
            comploted = true;
            m_policeAnim.SetBool("trigger",true);

            //talk
        }

        if (other.gameObject.CompareTag("Player") && !comploted && !isPolice)
        {
            comploted = true;
            m_policeAnim.SetBool("trigger", true);

            //talk
        }

        if (other.gameObject.CompareTag("Player") &&  isRaper)
        {
            PressText.gameObject.SetActive(true);
            activePaper = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isRaper)
        {
            PressText.gameObject.SetActive(false);
            paper.SetActive(false);
            activePaper = false;
        }
    }
}
