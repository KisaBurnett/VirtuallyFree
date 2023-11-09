// Credit to John French of gamedevbeginner.com
// https://gamedevbeginner.com/how-to-make-an-inventory-system-in-unity/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public GameObject emptyInvText;
    public Inventory inventory;
    public ItemDisplay[] slots;

    private void Start()
    {
        UpdateInventory();
    }

    void UpdateInventory()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (inventory.items.Count == 0)
            {
                emptyInvText.SetActive(true);
            }
            else
            {
                emptyInvText.SetActive(false);
            }

            if (i < inventory.items.Count)
            {
                slots[i].gameObject.SetActive(true);
                slots[i].UpdateItemDisplay(inventory.items[i].itemType.icon, i, inventory.items[i].itemType.description, inventory.items[i].itemType.name, inventory.items[i].hungerValue);
            }
            else
            {
                slots[i].gameObject.SetActive(false);
            }
        }
    }

    public void RemoveItem(int itemIndex)
    {
        inventory.items.RemoveAt(itemIndex);
        UpdateInventory();
    }
}
