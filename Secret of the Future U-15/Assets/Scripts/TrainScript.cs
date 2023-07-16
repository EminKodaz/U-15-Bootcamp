using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainScript : MonoBehaviour
{
    [SerializeField] private BoxCollider collider;

    [SerializeField] private Text TextM;

    private void Start()
    {
        TextM.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.instance.MissionFirst == false && GameManager.instance.MissionSecond == false)
            {
                TextM.gameObject.SetActive(true);
                TextM.text = "Ýlk ve Ýkinci görevini tamamlamalýsýn";
            }
            else if (GameManager.instance.MissionFirst == true && GameManager.instance.MissionSecond == false)
            {
                TextM.gameObject.SetActive(true);
                TextM.text = "Ýkinci görevini tamamlamalýsýn";
            }
            else if (GameManager.instance.MissionThird == false)
            {
                collider.enabled = false;
                GameManager.instance.MissionThird = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TextM.gameObject.SetActive(false);
        TextM.text = "";
    }
}
