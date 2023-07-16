using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalAttackTime : MonoBehaviour
{
    [SerializeField] private List<Transform> ZombiePos = new List<Transform>();
    [SerializeField] private List<GameObject> ZombieObj = new List<GameObject>();

    [SerializeField] private GameObject ZombieAttackTime;
    [SerializeField] private AudioSource ZombieAttackMusic;
    bool fight = false;
    bool m_Complated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !m_Complated)
        {
            ZombieAttackTime.SetActive(true);

            StartCoroutine(ReduceSound());

            for (int i = 0; i < 4; i++)
            {
                Instantiate(SpanObject(), RandomPoint().position, Quaternion.identity);
            }
            m_Complated = true;
        }
    }

    private void Update()
    {
        if (ZombieAttackMusic != null && fight == true)
        {
            ZombieAttackMusic.volume -= Time.deltaTime / 10;
            if (ZombieAttackMusic.volume <= 0.01f)
            {
                fight = false;
                ZombieAttackMusic.volume = .5f;
                ZombieAttackTime.SetActive(false);
            }
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

    IEnumerator ReduceSound()
    {
        yield return new WaitForSeconds(30);
        fight = true;
    }
}
