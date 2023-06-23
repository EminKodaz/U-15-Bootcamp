using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrablePoint;
    [SerializeField] private LayerMask pickUpLayerMask;

    private ObjectGrable objectGrables;
    private Animator anim;
    WeaponManager weaponManager;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        weaponManager = GetComponentInChildren<WeaponManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrables == null)
            {
                float pickUpDÝstance = 2;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDÝstance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrables))
                    {
                        objectGrables.Grab(objectGrablePoint);

                        anim.SetBool("Hold", true);
                        weaponManager.InventoryOpenOrClose = true;

                    }
                }
            }
            else
            {
                objectGrables.Drop();
                objectGrables = null;
                anim.SetBool("Hold", false);
                weaponManager.InventoryOpenOrClose = false;
            }
        }
        float rotationAmount = Input.GetAxis("Mouse ScrollWheel");
        if (rotationAmount != 0 && objectGrables != null)
        {
            objectGrables.RotateObject(rotationAmount * 50);
        }
    }
}
