using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalAttackTime : MonoBehaviour
{
    [SerializeField] private List<Transform> ZombiePos = new List<Transform>();
    [SerializeField] private List<GameObject> ZombieObj = new List<GameObject>();

    bool m_Complated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !m_Complated)
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(SpanObject(), RandomPoint().position, Quaternion.identity);
            }
            m_Complated = true;
        }
    }

    public GameObject SpanObject()
    {
        int random = Random.Range(0, ZombieObj.Count);
        GameObject currentSpawnObject = ZombieObj[random];
        return currentSpawnObject;
    }

    public Transform RandomPoint()
    {
        if (ZombiePos.Count == 0)
        {
            Debug.LogError("Spawn noktalarý listesi boþ.");
            return null;
        }

        int random = Random.Range(0, ZombiePos.Count);
        Transform pos = ZombiePos[random].transform;
        ZombiePos.RemoveAt(random); // Kullanýlan spawn noktasýný listeden çýkar
        return pos;
    }
}
