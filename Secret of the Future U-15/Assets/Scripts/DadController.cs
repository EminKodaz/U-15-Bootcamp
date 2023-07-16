using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadController : MonoBehaviour
{
    [SerializeField] private GameObject Text;

    private void Start()
    {
        Text.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Text.SetActive(true);
            Destroy(Text, 3f);
            Destroy(gameObject,5f);
        }
    }
}
