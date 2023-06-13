using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public float pistolDamage = 10f;
    public float range = 100f;

    public Camera fpsCam;


    public GameObject pistolAimLook;
    public GameObject pistolNormalLook;
    private bool isAiming = false;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetMouseButtonDown(1)) // Sað týk kontrolü
        {
            ToggleAimObjects();

            Debug.Log("Saðtýk");
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyDamage enemy = hit.transform.GetComponent<EnemyDamage>();

            if (enemy != null)
            {
                enemy.TakeDamage(pistolDamage);
            }
        }
    }

    //private void OnMouseDown()
    //{

    //}

    private void ToggleAimObjects()
    {
        if (isAiming)
        {
            pistolAimLook.SetActive(true);
            pistolNormalLook.SetActive(false);
        }
        else
        {
            pistolAimLook.SetActive(false);
            pistolNormalLook.SetActive(true);
        }

        isAiming = !isAiming;
    }

}
