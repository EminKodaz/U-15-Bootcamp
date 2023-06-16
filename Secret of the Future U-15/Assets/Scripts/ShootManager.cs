using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public float pistolDamage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public Animator camAnim;
    bool focus = false;

    public bool rifle;
    public bool gun;
    public GameObject scopeOverlay;


    void Update()
    {
        if (Input.GetMouseButtonDown(1) && gun==true) // Sað týk kontrolü
        {
            focus = !focus;
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

        if (Input.GetMouseButtonDown(1) && rifle==true) // Sað týk kontrolü
        {
            focus = !focus;
            camAnim.SetBool("focus", focus);
            StartCoroutine(ScopeOverlayZoomDelay(focus));
        }
    }

    public void Shoot()
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
    IEnumerator ScopeOverlayZoomDelay(bool _focus)
    {
        yield return new WaitForSeconds(0.3f);

        if (_focus)
        {
            GetComponentInParent<FirstPersonController>().MoveSpeed = 2;

            fpsCam.cullingMask = fpsCam.cullingMask & ~(1 << 11);
            fpsCam.fieldOfView = 20;
        }
        else
        {
            GetComponentInParent<FirstPersonController>().MoveSpeed = 4;

            fpsCam.cullingMask = fpsCam.cullingMask | (1 << 11);
            fpsCam.fieldOfView = 75;
        }
        scopeOverlay.SetActive(_focus);
    }


}
