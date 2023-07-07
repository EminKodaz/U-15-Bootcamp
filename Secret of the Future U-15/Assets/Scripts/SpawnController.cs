using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public List<GameObject> spawnObject = new List<GameObject>();
    public List<Transform> spawnPoint = new List<Transform>();

    private void Start()
    {
        foreach (GameObject Sobject in spawnObject)
        {
            Instantiate(Sobject, RandomPoint());
        }
    }

    public Transform RandomPoint()
    {
        if (spawnPoint.Count == 0)
        {
            Debug.LogError("Spawn noktalarý listesi boþ.");
            return null;
        }

        int random = Random.Range(0, spawnPoint.Count);
        Transform pos = spawnPoint[random].transform;
        spawnPoint.RemoveAt(random); // Kullanýlan spawn noktasýný listeden çýkar
        return pos;
    }
}
