using StarterAssets;
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
    public Animator camAnim;
    bool focus = false;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetMouseButtonDown(1)) // Sað týk kontrolü
        {
            focus = !focus;
            //ToggleAimObjects();
            Debug.Log("Saðtýk");
            camAnim.SetBool("focus", focus);
            if (focus)
            {
                GetComponentInParent<FirstPersonController>().MoveSpeed = 2;
            }
            else
            {
                GetComponentInParent<FirstPersonController>().MoveSpeed = 4;
            }
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
