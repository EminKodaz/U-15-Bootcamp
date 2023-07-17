using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastScenetext : MonoBehaviour
{
    [SerializeField] private GameObject Text;

    private void Start()
    {
        Text.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Text.SetActive(true);
        Destroy(Text,3f);
    }
}
