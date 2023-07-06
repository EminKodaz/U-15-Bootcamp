using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonİtem : MonoBehaviour
{
    public int id;
    public Item item;

    public void GunUpgrade()
    {
        WeaponManager.instanceW.AddBullet(id, item, this.gameObject);
    }
}
