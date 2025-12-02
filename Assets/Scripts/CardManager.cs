using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

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

    public void PlayHand()
    {
        List<List<Card>> cards = new List<List<Card>>();
        // get rows of selected cards
        foreach (CardHolder ch in cardHolders)
        {
            List<Card> row = new List<Card>();
            foreach(CardSlot cs in ch.cardSlots)
            {
                Card card = cs.GetComponentInChildren<Card>();
                if (!card.selected) continue;
                row.Add(card);
            }
            cards.Add(row);
        }
        // check if hand form is correct (at least two rows & one row must have a single card)
        int rowAtLeast1 = 0, rowExactly1 = 0;
        foreach(List<Card> row in cards) {
            if (row.Count > 0) rowAtLeast1 += 1;
            if (row.Count == 1) rowExactly1 += 1;
        }
        if (rowAtLeast1 >= 2 && rowExactly1 >= 1) {
            Debug.Log("Valid Hand!");
        }
        else {
            Debug.Log("Invalid Hand!");
            return;
        }
        // start score validation
        Card single = null;
        List<List<Card>> otherCards = new List<List<Card>>();
        foreach(List<Card> row in cards) {
            if (row.Count == 1 && single == null) {
                single = row[0];
            }
            else {
                otherCards.Add(row);
            }
        }

        foreach(List<Card> row in otherCards) {
            var values = row.Select(x => new List<int>(){x.value}).ToList();
            // var values = row.Select(x => new List<int>(){x.value});
            Debug.Log("doing a row");
            if (values.Count > 0) Scoring.CheckHand(values, single.value);
        }
    }
}
