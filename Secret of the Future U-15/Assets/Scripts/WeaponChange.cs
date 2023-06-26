using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public GameObject pistol;
    public GameObject rifle;
    public GameObject rifleweapon;
    public GameObject rifleImage;
    public GameObject ak47;
    public GameObject ak47weapon;
    public GameObject ak47Image;

    public GameObject Inventory;
    bool OpenInventory = false;
    [SerializeField] private float radius;
    public bool pistolActive = true;
    public bool rifleActive = false;
    public bool rifleActiveReceived = false;
    public bool ak47Active = false;
    public bool ak47ActiveReceived = false;

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
                ak47.SetActive(false);
                rifle.SetActive(true);
                pistol.SetActive(false);
                pistolActive = false;
            }
            if (ak47 != null && ak47Active == true)
            {
                ak47.SetActive(true);
                rifle.SetActive(false);
                pistol.SetActive(false);
                pistolActive = false;
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
                GetComponentInParent<FirstPersonController>().RotationSpeed = 0;
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                GetComponentInParent<FirstPersonController>().MoveSpeed = 4;
                GetComponentInChildren<Animator>().enabled = true;
                GetComponentInChildren<WeaponManager>().InventoryOpenOrClose = false;
                GetComponentInParent<FirstPersonController>().RotationSpeed = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }
            if (ak47Active == true)
            {
                ak47Image.gameObject.SetActive(true);
                rifleImage.gameObject.SetActive(false);

            }
            if (rifleActive == true)
            {

                ak47Image.gameObject.SetActive(false);
                rifleImage.gameObject.SetActive(true);
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
            if (hitCollider.CompareTag("AK"))
            {
                if (pistolActive == false && !ak47Active)
                {
                    rifleActive = false;
                    ak47Active = true;
                    pistolActive = false;
                    ak47.SetActive(true);
                    rifle.SetActive(false);
                    pistol.SetActive(false);
                    Instantiate(rifleweapon, transform.position, transform.rotation);
                    Destroy(hitCollider.gameObject);
                    rifleActiveReceived = false;
                    ak47ActiveReceived = true;
                }
                else if(pistolActive == true && rifleActiveReceived == true)
                {
                    rifleActive = false;
                    ak47Active = true;
                    pistolActive = false;
                    ak47.SetActive(true);
                    rifle.SetActive(false);
                    pistol.SetActive(false);
                    Instantiate(rifleweapon, transform.position, transform.rotation);
                    Destroy(hitCollider.gameObject);
                    rifleActiveReceived = false;
                    ak47ActiveReceived = true;
                }
                else
                {
                    rifleActive = false;
                    ak47Active = true;
                    pistolActive = false;
                    ak47.SetActive(true);
                    rifle.SetActive(false);
                    pistol.SetActive(false);
                    Destroy(hitCollider.gameObject);
                    ak47ActiveReceived = true;
                    rifleActiveReceived = false;

                }
            }
            if (hitCollider.CompareTag("RÝFLE"))
            {
                if (pistolActive == false && !rifleActive)
                {
                    rifleActive = true;
                    ak47Active = false;
                    pistolActive = false;
                    ak47.SetActive(false);
                    rifle.SetActive(true);
                    pistol.SetActive(false);
                    Instantiate(ak47weapon, transform.position, transform.rotation);
                    Destroy(hitCollider.gameObject);
                    ak47ActiveReceived = false;
                    rifleActiveReceived = true;
                }
                else if(pistolActive == true && ak47ActiveReceived == true)
                {
                    rifleActive = true;
                    ak47Active = false;
                    pistolActive = false;
                    ak47.SetActive(false);
                    rifle.SetActive(true);
                    pistol.SetActive(false);
                    Instantiate(ak47weapon, transform.position, transform.rotation);
                    Destroy(hitCollider.gameObject);
                    ak47ActiveReceived = false;
                    rifleActiveReceived = true;
                }
                else
                {
                    rifleActive = true;
                    ak47Active = false;
                    pistolActive = false;
                    ak47.SetActive(false);
                    rifle.SetActive(true);
                    pistol.SetActive(false);
                    Destroy(hitCollider.gameObject);
                    rifleActiveReceived = true;
                    ak47ActiveReceived = false;
                }
            }
        }
    }
}
