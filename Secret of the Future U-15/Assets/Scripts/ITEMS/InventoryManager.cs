using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> ›tems = new List<Item>();

    public Transform itemContent;
    public GameObject Inventory›tem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        ›tems.Add(item);
    }

    public void Remove(Item item)
    {
        ›tems.Remove(item);
    }

    public void List›tems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in ›tems)
        {
            GameObject obj = Instantiate(Inventory›tem, itemContent);
            //var itemName = obj.transform.Find("Item/itemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("icon").GetComponent<Image>();
            obj.transform.GetComponent<Button›tem>().id = item.id;
            obj.transform.GetComponent<Button›tem>().item = item;

            //itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
    }
}
