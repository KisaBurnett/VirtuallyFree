// Credit to John French of gamedevbeginner.com
// https://gamedevbeginner.com/how-to-make-an-inventory-system-in-unity/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;
    public int hungerMin;
    public int hungerMax;

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}
