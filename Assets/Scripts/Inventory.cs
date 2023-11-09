// Credit to John French of gamedevbeginner.com
// https://gamedevbeginner.com/how-to-make-an-inventory-system-in-unity/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public int maxItems = 8;
    public List<ItemInstance> items = new();

    public bool AddItem(ItemInstance itemToAdd)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i] == null)
            {
                items[i] = itemToAdd;
                return true;
            }
        }

        if(items.Count < maxItems)
        {
            items.Add(itemToAdd);
            return true;
        }

        Debug.Log("No inventory space!");
        return false;
    }

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}
