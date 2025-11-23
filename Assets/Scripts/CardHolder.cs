using UnityEngine;

public class CardHolder : MonoBehaviour
{
    public int cardSlots = 0;
    public CardSlot cardSlotPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < cardSlots; i++)
        {
            CardSlot cSlot = Instantiate(cardSlotPrefab, gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
