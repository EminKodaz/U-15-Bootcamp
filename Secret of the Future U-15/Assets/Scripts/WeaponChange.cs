using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public bool OpenInventory = false;
    [SerializeField] private float radius;
    public bool pistolActive = true;
    public bool rifleActive = false;
    public bool ak47Active = false;
    public bool escapeActive = false;
    InventoryManager ýnventoryManager;
    [SerializeField] private WeaponManager[] shoot;
    private void Start()
    {
        ýnventoryManager = GetComponent<InventoryManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && shoot[1].isReloading == false && shoot[2].isReloading == false)
        {
            pistol.SetActive(true);
            rifle.SetActive(false);
            ak47.SetActive(false);
            pistolActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && shoot[0].isReloading == false && shoot[2].isReloading == false)
        {
            if (ak47 != null && ak47Active == true)
            {
                ak47.SetActive(true);
                rifle.SetActive(false);
                pistol.SetActive(false);
                pistolActive = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && shoot[0].isReloading == false && shoot[1].isReloading == false)
        {
            if (rifle != null && rifleActive == true)
            {
                ak47.SetActive(false);
                rifle.SetActive(true);
                pistol.SetActive(false);
                pistolActive = false;
            }
        }

        if (GameManager.instance.TabOpen == true)
        {
            escapeActive = true;
            TabClose();
            Inventory.SetActive(false);
        }
        else
        {
            escapeActive = false;
        }

        if (Input.GetKeyDown(KeyCode.Tab) && escapeActive == false)
        {
            OpenInventory = !OpenInventory;
            Cursor.lockState = OpenInventory ? CursorLockMode.None : CursorLockMode.Locked;
            Inventory.SetActive(OpenInventory);
            if (OpenInventory)
            {
                GetComponentInParent<FirstPersonController>().MoveSpeed = 0;
                GetComponentInChildren<Animator>().enabled = false;
                GetComponentInChildren<WeaponManager>().InventoryOpenOrClose = true;
                GetComponentInChildren<WeaponManager>().camAnim.SetBool("focus", false);
                GetComponentInParent<FirstPersonController>().RotationSpeed = 0;
                GameManager.instance.HurtClose(false);

                if (InventoryManager.Instance != null)
                {
                    InventoryManager.Instance.ListÝtems();
                }
            }
            else
            {
                TabClose();
            }
            if (ak47Active == true)
            {
                ak47Image.gameObject.SetActive(true);

            }
            if (rifleActive == true)
            {
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
                    ak47Active = true;
                    pistolActive = false;
                    ak47.SetActive(true);
                    rifle.SetActive(false);
                    pistol.SetActive(false);
                    Destroy(hitCollider.gameObject);
                }
                else if (pistolActive == true)
                {
                    ak47Active = true;
                    pistolActive = false;
                    ak47.SetActive(true);
                    rifle.SetActive(false);
                    pistol.SetActive(false);
                    Destroy(hitCollider.gameObject);
                }
                else
                {
                    ak47Active = true;
                    pistolActive = false;
                    ak47.SetActive(true);
                    rifle.SetActive(false);
                    pistol.SetActive(false);
                    Destroy(hitCollider.gameObject);

                }
            }
            if (hitCollider.CompareTag("RÝFLE"))
            {
                if (pistolActive == false && !rifleActive)
                {
                    rifleActive = true;
                    pistolActive = false;
                    ak47.SetActive(false);
                    rifle.SetActive(true);
                    pistol.SetActive(false);
                    Destroy(hitCollider.gameObject);
                }
                else if (pistolActive == true)
                {
                    rifleActive = true;
                    pistolActive = false;
                    ak47.SetActive(false);
                    rifle.SetActive(true);
                    pistol.SetActive(false);
                    Destroy(hitCollider.gameObject);
                }
                else
                {
                    rifleActive = true;
                    pistolActive = false;
                    ak47.SetActive(false);
                    rifle.SetActive(true);
                    pistol.SetActive(false);
                    Destroy(hitCollider.gameObject);
                }
            }
            if (hitCollider.CompareTag("Mag") && ýnventoryManager.TotalÝtemCount > ýnventoryManager.CurrentÝtem)
            {
                hitCollider.GetComponent<PickUpÝtem>().Pickup();
            }
        }
    }

    public void TabClose()
    {
        GetComponentInParent<FirstPersonController>().MoveSpeed = 4;
        GetComponentInChildren<Animator>().enabled = true;
        GetComponentInChildren<WeaponManager>().InventoryOpenOrClose = false;
        GetComponentInParent<FirstPersonController>().RotationSpeed = 1;
    }
}
