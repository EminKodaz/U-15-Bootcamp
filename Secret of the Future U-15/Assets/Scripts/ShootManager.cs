using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public float Damage;
    public float range = 100f;
    public GameObject impactEffect;
    public float impactForce = 30;
    public Camera fpsCam;
    public bool rifle = false;
    public Rigidbody bulletShell;
    public Transform shellInsPos;

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, ~LayerMask.GetMask("lens")))
        {

            EnemyDamage enemy = hit.collider.GetComponent<EnemyDamage>();
            EnemyDamage enemyhead = hit.collider.GetComponentInParent<EnemyDamage>();

            if (hit.collider.name == "AttackHead" && enemyhead != null)
            {
                enemyhead.TakeDamage(50);
            }

            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, .1f);
        }

    }

    public void Shell()
    {
        Rigidbody clone = Instantiate(bulletShell, shellInsPos.transform.position, shellInsPos.transform.rotation) as Rigidbody;
        clone.velocity = transform.right * 5;
        Destroy(clone.gameObject, 2f);
    }

}
