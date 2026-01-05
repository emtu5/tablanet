using UnityEngine;

using System;
using System.Collections.Generic;
using SerializeReferenceEditor;
[Serializable]
public class ItemEffect {
    public ItemData itemData;
    [SerializeReference]
    [SR]
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
                return commonItems[UnityEngine.Random.Range(0, commonItems.Count - 1)];
            case ItemData.Rarity.UNCOMMON:
                return uncommonItems[UnityEngine.Random.Range(0, uncommonItems.Count - 1)];
            case ItemData.Rarity.RARE:
                return rareItems[UnityEngine.Random.Range(0, rareItems.Count - 1)];
            default:
                return commonItems[UnityEngine.Random.Range(0, commonItems.Count - 1)];
        }
    }
}
