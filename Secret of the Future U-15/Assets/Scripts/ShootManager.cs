using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public float pistolDamage = 10f;
    public float range = 100f;
    

    public Camera fpsCam;

    public void Shoot()
    {
        RaycastHit hit;
        Vector3 firePos = new Vector3(fpsCam.transform.position.x,fpsCam.transform.position.y,fpsCam.transform.position.z+0.2f);

        if (Physics.Raycast(firePos, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyDamage enemy = hit.transform.GetComponent<EnemyDamage>();

            if (enemy != null)
            {
                enemy.TakeDamage(pistolDamage);
            }
        }
    }

}
