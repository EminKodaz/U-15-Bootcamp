using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMod : MonoBehaviour
{
    [Header("Zombi Spawn")]
    public List<GameObject> ZombiePrefabs = new List<GameObject>();
    public List<Transform> spawnPoint = new List<Transform>();
    [SerializeField] int ýnstateCount = 5;
    [SerializeField] private float RoundTime;

    private void Start()
    {
        StartCoroutine(ZombieAttackTimeRound());
    }

    public Transform RandomPoint()
    {
        int random = Random.Range(0, spawnPoint.Count);
        Transform pos = spawnPoint[random].transform;
        return pos;
    }

    public GameObject SpanObject()
    {
        int random = Random.Range(0, ZombiePrefabs.Count);
        GameObject currentSpawnObject = ZombiePrefabs[random];
        return currentSpawnObject;
    }

    IEnumerator ZombieAttackTimeRound()
    {
        if (ýnstateCount < 9)
        {
            ýnstateCount++;
        }
        else
        {
            ýnstateCount = 10;
        }
        for (int i = 0; i < ýnstateCount; i++)
        {
            Instantiate(SpanObject(), RandomPoint().position, Quaternion.identity);
        }

        yield return new WaitForSeconds(RoundTime);

        StartCoroutine(ZombieAttackTimeRound());
    }
}
