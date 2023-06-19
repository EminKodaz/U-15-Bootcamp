using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAk47 : WeaponManager
{
    public override void Focus()
    {
        focusGuns = !focusGuns;
        camAnim.SetBool("focus", focusGuns);
        if (focusGuns)
        {
            GetComponentInParent<FirstPersonController>().MoveSpeed = 2;
        }
        else
        {
            GetComponentInParent<FirstPersonController>().MoveSpeed = 4;
        }
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
