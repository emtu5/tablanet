using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    public ItemDefinition itemList;
    public Item itemPrefab;
    public List<ShopPanel> panels;
    public List<Item> items;
    public Item CreateItem()
    {
        Item i = Instantiate(itemPrefab, gameObject.transform) as Item;
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
        i.data = chosen.itemData; i.effect = chosen.effect;
        i.effect.Init();
        return i;
        // GameManager.Instance.items.Add(i);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    void Start()
    {
        foreach (ShopPanel panel in panels)
        {
            Item i = CreateItem();
            items.Add(i);
        }
        InitPanels();
    }

    public void InitPanels()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            // panels[i].image.sprite = null;
            panels[i].name.text = items[i].data.itemName;
            panels[i].type.text = items[i].data.type.ToString();
            panels[i].description.text = items[i].data.description;
            switch (items[i].data.rarity)
            {
                case ItemData.Rarity.COMMON:
                    panels[i].GetComponent<Image>().color = new Color(0.9f, 0.9f, 1f, 0.4f); break;
                case ItemData.Rarity.UNCOMMON:
                    panels[i].GetComponent<Image>().color = new Color(0.5f, 1f, 0.5f, 0.4f); break;
                case ItemData.Rarity.RARE:
                    panels[i].GetComponent<Image>().color = new Color(1f, 0.5f, 0.5f, 0.4f); break;
                default:
                    panels[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.4f); break;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
