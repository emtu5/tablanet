using UnityEngine;
using System;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public EffectsManager effectsManager;
    public Item itemPrefab;

    public void CreateItem()
    {
        Item i = Instantiate(itemPrefab, GameManager.Instance.transform) as Item;
        GameManager.Instance.items.Add(i);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    void Start()
    {
        CreateItem();
        CreateItem();
        CreateItem();
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
