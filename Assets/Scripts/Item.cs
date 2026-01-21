using UnityEngine;
using System;
using SerializeReferenceEditor;
using UnityEngine.U2D;

public class Item : MonoBehaviour
{
    public ItemData data;
    [SerializeReference]
    [SR]
    public Effect effect;
    public bool used;

    public SpriteRenderer backing;
    public SpriteRenderer icon;
    public SpriteAtlas itemAtlas;

    public void ItemClick()
    {
        if (data.type == ItemData.ItemType.PASSIVE) return;
        if (!effect.IsValid()) return;
        // Debug.Log(effect.IsValid());
        if (data.type == ItemData.ItemType.CONSUMABLE)
        {
            effect.Perform();
            GameManager.Instance.items.Remove(this);
            Destroy(gameObject);
        }
        if (data.type == ItemData.ItemType.ONCE_PER_ROUND && !used) {
            effect.Perform();
            used = true;
        }
        Debug.Log("you did click!");
    }

    public void ItemScore()
    {
        if (data.type != ItemData.ItemType.PASSIVE) return;
        Debug.Log(effect.IsValid());
        if (effect.IsValid()) effect.Perform();
        Debug.Log("it scored!!!");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // if (effect != null) effect.Init();
    }

    public string GetTooltip() {
        return String.Format("{0}\n{1}\n{2}", data.itemName, data.type, data.description);
    }

    public void Init() {
        Debug.Log("nyan");
        backing.sprite = itemAtlas.GetSprite(data.rarity.ToString());
        icon.sprite = itemAtlas.GetSprite(data.itemName);
        effect.Init();
        data.description = String.Format(data.description, effect.GetData());
    }
}
