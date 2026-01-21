using UnityEngine;
using SerializeReferenceEditor;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public enum ItemType
    {
        PASSIVE,
        ONCE_PER_ROUND,
        CONSUMABLE
    }

    public enum Rarity
    {
        COMMON,
        UNCOMMON,
        RARE
    }

    public ItemType type;
    public Rarity rarity;
    public string id;
    public string itemName;
    public string description;
    public Sprite icon;
    // [SerializeReference]
    // [SR]
    // public Effect effect;
}
