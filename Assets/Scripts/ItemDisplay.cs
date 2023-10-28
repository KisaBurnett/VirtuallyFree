// Credit to John French of gamedevbeginner.com
// https://gamedevbeginner.com/how-to-make-an-inventory-system-in-unity/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public int itemIndex;
    public Image image;

    public void UpdateItemDisplay(Sprite newSprite, int newItemIndex)
    {
        image.sprite = newSprite;
        itemIndex = newItemIndex;
    }
}
