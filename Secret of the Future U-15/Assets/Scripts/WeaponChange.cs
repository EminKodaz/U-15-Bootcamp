using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public GameObject pistol;
    public GameObject rifle;
    public GameObject ak47;

    public GameObject Inventory;
    bool OpenInventory = false;
    [SerializeField] private float radius;
    bool pistolActive = true;
    bool rifleActive = false;
    bool ak47Active = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pistol.SetActive(true);
            rifle.SetActive(false);
            ak47.SetActive(false);
            pistolActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (rifle != null && rifleActive == true)
            {
                pistol.SetActive(false);
                ak47.SetActive(false);
                rifle.SetActive(true);
            }
            if (ak47 != null && ak47Active == true)
            {
                ak47.SetActive(true);
                rifle.SetActive(false);
                pistol.SetActive(false);

            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenInventory = !OpenInventory;
            Inventory.SetActive(OpenInventory);
            if (OpenInventory)
            {
                GetComponentInParent<FirstPersonController>().MoveSpeed = 0;
                GetComponentInChildren<Animator>().enabled = false;
                GetComponentInChildren<WeaponManager>().InventoryOpenOrClose = true;
                GetComponentInChildren<WeaponManager>().camAnim.SetBool("focus", false);
            }
            else
            {
                GetComponentInParent<FirstPersonController>().MoveSpeed = 4;
                GetComponentInChildren<Animator>().enabled = true;
                GetComponentInChildren<WeaponManager>().InventoryOpenOrClose = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ExplosionDamage();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public void ExplosionDamage()
    {
        Collider[] Guns = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in Guns)
        {
            if (hitCollider.name == "Ak")
            {
                if (pistolActive == false)
                {
                    rifleActive = false;
                    ak47Active = true;
                    pistolActive = false;
                    ak47.SetActive(true);
                    rifle.SetActive(false);
                    pistol.SetActive(false);
                }
                else
                {
                    rifleActive = false;
                    ak47Active = true;
                    pistolActive = false;
                    ak47.SetActive(true);
                    rifle.SetActive(false);
                    pistol.SetActive(false);

                }
            }
            if (hitCollider.name == "Rifle")
            {
                if (pistolActive == false)
                {
                    rifleActive = true;
                    ak47Active = false;
                    pistolActive = false;
                    ak47.SetActive(false);
                    rifle.SetActive(true);
                    pistol.SetActive(false);
                }
                else
                {
                    rifleActive = true;
                    ak47Active = false;
                    pistolActive = false;
                    ak47.SetActive(false);
                    rifle.SetActive(true);
                    pistol.SetActive(false);
                }
            }
        }
    }
}
