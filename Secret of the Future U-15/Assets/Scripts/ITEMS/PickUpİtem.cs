using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpİtem : MonoBehaviour
{
    public Item item;

    public void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }
}
