using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRifle : WeaponManager
{
    public GameObject scopeOverlay;
    public override void Focus()
    {
        focusGuns = !focusGuns;
        camAnim.SetBool("focus", focusGuns);
        StartCoroutine(ScopeOverlayZoomDelay());
    }

    public override void Shoots()
    {
        shootVfx.Play();
        //pistolShootSound.Play();
        shootManager.Shoot();
        _animator.SetTrigger("Fire");
        nextTime = 0;
    }

    IEnumerator ScopeOverlayZoomDelay()
    {
        yield return new WaitForSeconds(0.3f);

        if (focusGuns)
        {
            fpsCam.cullingMask = fpsCam.cullingMask & ~(1 << 11);
            fpsCam.fieldOfView = 20;
            GetComponentInParent<FirstPersonController>().MoveSpeed = 2;
        }
        else
        {
            fpsCam.cullingMask = fpsCam.cullingMask | (1 << 11);
            fpsCam.fieldOfView = 75;
            GetComponentInParent<FirstPersonController>().MoveSpeed = 4;
        }
        scopeOverlay.SetActive(focusGuns);
    }
    private void OnDisable()
    {
        fpsCam.cullingMask = fpsCam.cullingMask | (1 << 11);
        fpsCam.fieldOfView = 75;
        GetComponentInParent<FirstPersonController>().MoveSpeed = 4;
        scopeOverlay.SetActive(false);

    }
}
