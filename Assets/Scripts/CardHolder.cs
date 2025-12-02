using UnityEngine;
using System;
using System.Collections.Generic;

public class CardHolder : MonoBehaviour
{
    public int totalSlots = 0;
    public CardSlot cardSlotPrefab;
    public List<CardSlot> cardSlots;
    float cardSpacing = 1.7f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void FillSlots()
    {
        Debug.Log(totalSlots);
        for (int i = 0; i < totalSlots; i++)
        {
            CardSlot cSlot = Instantiate(cardSlotPrefab, gameObject.transform);
            cSlot.transform.localPosition = new Vector3(-(totalSlots - 1) * cardSpacing / 2 + i * cardSpacing, 0, 0);
            cardSlots.Add(cSlot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
