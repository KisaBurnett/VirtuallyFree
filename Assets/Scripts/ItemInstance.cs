// Credit to John French of gamedevbeginner.com
// https://gamedevbeginner.com/how-to-make-an-inventory-system-in-unity/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance
{
    public int hungerValue;
    public ItemData itemType;
    
    public ItemInstance(ItemData itemData)
    {
        itemType = itemData;
        hungerValue = Random.Range(itemData.hungerMin, itemData.hungerMax);
    }
}
