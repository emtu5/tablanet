using UnityEngine;
using System;
using System.Collections.Generic;

public class EffectsManager : MonoBehaviour
{
    public CardManager cardManager;
    public RoundManager roundManager;
    public ItemManager itemManager;
    
    // Discard Selected
    public void Discard()
    {
        cardManager.DiscardCards();
        cardManager.DealCards();
    }

    public void Play(bool freeHand)
    {
        cardManager.PlayHand(freeHand);
    }

    public void AddMult(Card c, int amount)
    {
        c.extraMults += amount;
    }

    public void AddPoints(Card c, int amount)
    {
        c.extraPoints += amount;
    }

    public void ChangeValue(Card c, int value)
    {
        c.value = new List<int>{value};
    }

    public void ScoreMult(int amount)
    {
        cardManager.mults += amount;
        Debug.LogFormat("You're scoring {0} mults!", amount);
    }

    public void ScorePoints(int amount)
    {
        cardManager.points += amount;
        Debug.LogFormat("You're scoring {0} mults!", amount);
    }

    public List<CardHolder> GetCards()
    {
        return cardManager.cardHolders;
    }

    public bool IsHandValid()
    {
        return cardManager.ValidateHand() != null;
    }

    public void DoubleMult()
    {
        cardManager.xmults = 2;
    }
}
