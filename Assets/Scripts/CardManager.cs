using UnityEngine;
using System;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    public List<CardHolder> cardHolders;
    public Deck deck;
    void DealCards()
    {
        foreach (CardHolder ch in cardHolders)
        {
            foreach(CardSlot cs in ch.cardSlots)
            {
                if (transform.childCount > 0) continue;
                Card dealtCard = deck.deck[deck.deck.Count - 1];
                dealtCard.selectable = true;
                deck.deck.RemoveAt(deck.deck.Count - 1);
                dealtCard.transform.parent = cs.transform;
                dealtCard.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }
    
    void Start()
    {
        foreach (CardHolder ch in cardHolders)
        {
            Debug.Log(ch);
            ch.FillSlots();
        }
        deck.CreateDeck();
        DealCards();
    }
}
