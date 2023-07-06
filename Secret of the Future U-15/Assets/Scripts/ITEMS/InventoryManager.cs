using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> ›tems = new List<Item>();

    public Transform itemContentBullet;
    public Transform itemContentHealth;
    public GameObject Inventory›tem;
    public int Total›temCount = 4;
    public int Current›tem = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        if (Total›temCount > Current›tem)
        {
            Current›tem++;
            ›tems.Add(item);

        }
    }

    public void Remove(Item item)
    {
        Current›tem--;
        ›tems.Remove(item);
    }

    public void List›tems()
    {
        foreach (Transform item in itemContentBullet)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in itemContentHealth)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in ›tems)
        {
            if (item.HealthOrBullet == true)
            {
                GameObject obj = Instantiate(Inventory›tem, itemContentHealth);
                //var itemName = obj.transform.Find("Item/itemName").GetComponent<Text>();
                var itemIcon = obj.transform.Find("icon").GetComponent<Image>();
                var itemName = obj.transform.Find("BulletType").GetComponent<Text>();
                obj.transform.GetComponent<Button›tem>().id = item.id;
                obj.transform.GetComponent<Button›tem>().item = item;

                //itemName.text = item.itemName;
                itemIcon.sprite = item.icon;
                itemName.text = item.itemName;
            }
            else
            {
                GameObject obj = Instantiate(Inventory›tem, itemContentBullet);
                //var itemName = obj.transform.Find("Item/itemName").GetComponent<Text>();
                var itemIcon = obj.transform.Find("icon").GetComponent<Image>();
                var itemName = obj.transform.Find("BulletType").GetComponent<Text>();
                obj.transform.GetComponent<Button›tem>().id = item.id;
                obj.transform.GetComponent<Button›tem>().item = item;

                //itemName.text = item.itemName;
                itemIcon.sprite = item.icon;
                itemName.text = item.itemName;
            }
        }
    }
}
