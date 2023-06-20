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
    }

    public override void Shoots()
    {
        shootVfx.Play();
        //pistolShootSound.Play();
        shootManager.Shoot();
        _animator.SetTrigger("Fire");
        nextTime = 0;
    }
}
