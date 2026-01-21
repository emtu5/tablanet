using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CardManager : MonoBehaviour
{
    public List<CardHolder> cardHolders;
    public Deck deck;
    public Transform discardPile;
    public RoundManager roundManager;
    public int points;
    public int mults;
    public int xmults;
    public AudioSource deal;
    public void DealCards()
    {
        foreach (CardHolder ch in cardHolders)
        {
            foreach(CardSlot cs in ch.cardSlots)
            {
                Debug.Log(cs.transform.childCount);
                if (cs.transform.childCount > 0) continue;
                if (deck.deck.Count == 0) continue;
                Card dealtCard = deck.deck[deck.deck.Count - 1];
                dealtCard.selectable = true;
                deck.deck.RemoveAt(deck.deck.Count - 1);
                dealtCard.transform.parent = cs.transform;
                dealtCard.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
        deal.Play();
    }
    
    public void DiscardCards() 
    {
        foreach (CardHolder ch in cardHolders)
        {
            foreach(CardSlot cs in ch.cardSlots)
            {
                if (cs.transform.childCount == 0) continue;
                Card card = cs.GetComponentInChildren<Card>();
                if (!card.selected) continue;
                card.selected = false;
                card.selectable = false;
                card.transform.parent = discardPile;
                card.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
        deal.mute = false;
    }

    void Start()
    {
        foreach (CardHolder ch in cardHolders)
        {
            Debug.Log(ch);
            ch.FillSlots();
        }
        deck.CreateDeck();
        deal.mute = true;
        DealCards();
        // deal.mute = false;
    }

    public async void PlayHand(bool freeHand = false)
    {
        var cards = ValidateHand();
        if (cards == null) return;
        
        roundManager.playButton.interactable = false;
        
        // scores;
        points = 0;
        mults = 1;
        xmults = 1;
        foreach(List<Card> row in cards) {
            foreach(Card c in row) {  
                await waitCardScore(c);
            }
        }
        //items
        foreach (Item i in GameManager.Instance.items)
        {
            if (i.data.type != ItemData.ItemType.PASSIVE) continue;
            Debug.Log("ITEM!!!");
            i.ItemScore();
        }
        mults *= xmults;
        // how do I clean architecture
        roundManager.ShowHandValue(points, mults);
        roundManager.AddToTotal();
        if (!freeHand) roundManager.PlayHand();
        DiscardCards();
        DealCards();

        roundManager.playButton.interactable = true;
    }

    public async Task waitCardScore(Card c) {
        points += c.GetValue();
        mults += c.mults;
        c.Score();
        await Task.Delay(500);
    }

    public void ForcePlayHand()
    {
        
    }
    
    public List<List<Card>> ValidateHand()
    {
        List<List<Card>> cards = new List<List<Card>>();
        // get rows of selected cards
        foreach (CardHolder ch in cardHolders)
        {
            List<Card> row = new List<Card>();
            foreach(CardSlot cs in ch.cardSlots)
            {
                if (cs.transform.childCount == 0) continue;
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
            return null;
        }
        // start score validation
        int singleIndex = -1;
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].Count == 1 && singleIndex == -1)
            {
                singleIndex = i;
            }
        }

        // List<List<int>> finalValues = new List<List<int>>();
        for (int i = 0; i < cards.Count; i++)
        {
            if (i == singleIndex) continue;

            var values = cards[i].Select(x => x.value).ToList();
            values.Insert(0, cards[singleIndex][0].value);
            // var values = row.Select(x => new List<int>(){x.value});
            Debug.Log("doing a row");
            if (values.Count == 1) continue;
            Debug.LogFormat("row is used, length = {0}", values.Count);
            // TODO: refactor single value (that should also be part of the product)
            // TODO: maybe pick the single value before sending it to the Scoring Check
            var chosenValues = Scoring.CheckHand(values).ToList();
            if (chosenValues == null) {
                Debug.Log("Invalid Hand");
                return null;
            }
            else {
                Debug.Log("Valid Hand");
                cards[singleIndex][0].currentValue = chosenValues[0];
                for (int j = 0; j < cards[i].Count; j++)
                {
                    cards[i][j].currentValue = chosenValues[j + 1];
                }
                // finalValues.Add(chosenValues.ToList());
            }
        }

        return cards;
    }
}
