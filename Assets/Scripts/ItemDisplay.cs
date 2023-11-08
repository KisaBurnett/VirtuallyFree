// Credit to John French of gamedevbeginner.com
// https://gamedevbeginner.com/how-to-make-an-inventory-system-in-unity/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour
{
    public int itemIndex;
    public Image image;
    public InventoryDisplay invntryDisplay;
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI itemName;
    int hunger;


    public void UpdateItemDisplay(Sprite newSprite, int newItemIndex, string itemDesc, string itemNm, int foodLvl)
    {
        image.sprite = newSprite;
        itemIndex = newItemIndex;
        itemText.text = itemDesc;
        itemName.text = itemNm;
        hunger = foodLvl;
    }

    public void Eat()
    {
        //Debug.Log(hunger.ToString());
        PlayerStats.Instance.hunger += hunger;
        PlayerStats.Instance.hygiene -= 1;
        //Debug.Log(PlayerStats.Instance.hunger.ToString());
        invntryDisplay.RemoveItem(itemIndex);
    }
}
