using UnityEngine;
using System;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public EffectsManager effectsManager;
    public ItemDefinition itemList;
    public Item itemPrefab;

    public void CreateItem()
    {
        Item i = Instantiate(itemPrefab, GameManager.Instance.transform) as Item;
        int choice = UnityEngine.Random.Range(0, 99);
        ItemEffect chosen;
        if (choice < 70)
        {
            chosen = itemList.GetItem(ItemData.Rarity.COMMON);
            Debug.Log("COMMON");
        }
        else if (choice < 95)
        {
            chosen = itemList.GetItem(ItemData.Rarity.UNCOMMON);
            Debug.Log("UNCOMMON");
        }
        else
        {
            chosen = itemList.GetItem(ItemData.Rarity.RARE);
            Debug.Log("RARE");
        }
        i.data = chosen.itemData; i.effect = chosen.effect; i.effect.toolbox = effectsManager;
        // i.effect.Init();
        GameManager.Instance.items.Add(i);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    void Start()
    {
        // CreateItem();
        // CreateItem();
        // CreateItem();
        foreach(Item i in GameManager.Instance.items)
        {
            i.effect.toolbox = effectsManager;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
