using UnityEngine;

using SerializeReferenceEditor;

public class Item : MonoBehaviour
{
    public ItemData data;
    [SerializeReference]
    [SR]
    public Effect effect;
    public void ItemClick()
    {
        // if (data.type == ItemData.ItemType.PASSIVE) return;
        Debug.Log(effect.IsValid());
        if (effect.IsValid()) effect.Perform();
        Debug.Log("you did click!");
        if (data.type == ItemData.ItemType.CONSUMABLE)
        {
            GameManager.Instance.items.Remove(this);
            Destroy(gameObject);
        }
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
        effect.Init();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
