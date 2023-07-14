using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLastScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.LoadScenes(2);
        }
    }
}
