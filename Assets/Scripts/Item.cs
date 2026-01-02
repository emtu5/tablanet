using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData data;
    public Effect effect;

    public void ItemClick()
    {
        // if (data.type == ItemData.ItemType.PASSIVE) return;
        Debug.Log(effect.IsValid());
        if (effect.IsValid()) effect.Perform();
        Debug.Log("you did click!");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
