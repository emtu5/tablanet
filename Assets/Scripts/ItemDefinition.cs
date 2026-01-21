using UnityEngine;

using System;
using System.Collections.Generic;
// using SerializeReferenceEditor;
[Serializable]
public class ItemEffect {
    public ItemData itemData;
    [SerializeReference]
    // [SR]
    public Effect effect;
}

public class ItemDefinition : MonoBehaviour
{
    [SerializeField]
    List<ItemEffect> commonItems;
    [SerializeField]
    List<ItemEffect> uncommonItems;
    [SerializeField]
    List<ItemEffect> rareItems;

    public ItemEffect GetItem(ItemData.Rarity type)
    {
        switch (type)
        {
            case ItemData.Rarity.COMMON:
                return commonItems[UnityEngine.Random.Range(0, commonItems.Count)];
            case ItemData.Rarity.UNCOMMON:
                return uncommonItems[UnityEngine.Random.Range(0, uncommonItems.Count)];
            case ItemData.Rarity.RARE:
                return rareItems[UnityEngine.Random.Range(0, rareItems.Count)];
            default:
                return commonItems[UnityEngine.Random.Range(0, commonItems.Count)];
        }
    }
}
