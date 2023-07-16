using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsEnd : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(CreditDelay());
    }

    IEnumerator CreditDelay()
    {
        yield return new WaitForSeconds(41.5f);
        SceneManager.LoadScene("FirstScene");
    }
}

