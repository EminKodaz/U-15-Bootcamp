using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachine : MonoBehaviour
{
    [SerializeField] private GameObject PressText;
    bool Pressded = false;

    private void Start()
    {
        PressText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PressText.SetActive(true);
            Pressded = true;
        }
    }

    private void Update()
    {
        if (Pressded)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                StartCoroutine(GameManager.instance.LoadMenuAsync(0));
            }
        }
    }
}
