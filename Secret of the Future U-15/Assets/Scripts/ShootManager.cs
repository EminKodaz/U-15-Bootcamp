using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public float Damage;
    public float range = 100f;
    public GameObject impactEffect;
    public GameObject BloodEffect;
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

            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }


            if (hit.collider.name == "AttackHead" && enemyhead != null)
            {
                StartCoroutine(ImpactEffectDelay(hit,BloodEffect));
                enemyhead.TakeDamage(50);
            }
            if (hit.collider.tag == "Zombies")
            {
                StartCoroutine(ImpactEffectDelay(hit, BloodEffect));
            }
            else
            {
                StartCoroutine(ImpactEffectDelay(hit, impactEffect));
            }
        }

    }

    public void Shell()
    {
        Rigidbody clone = Instantiate(bulletShell, shellInsPos.transform.position, shellInsPos.transform.rotation) as Rigidbody;
        clone.velocity = transform.right * 5;
        Destroy(clone.gameObject, 2f);
    }

    IEnumerator ImpactEffectDelay(RaycastHit hit,GameObject effect)
    {
        yield return new WaitForSeconds(0.2f);
        GameObject impactGo = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGo, .2f);

    }

}
