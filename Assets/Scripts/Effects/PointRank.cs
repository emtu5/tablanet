using UnityEngine;

using System;
using System.Collections.Generic;

public class PointRank : Effect
{
    // [SerializeField]
    public int extraPoint;
    public string rank;
    public override void Perform()
    {
        Debug.Log("goober!");
        int pointRank = 0;
        var cards = toolbox.GetCards();
        Debug.Log(cards);
        Debug.Log("goober!");
        foreach (CardHolder ch in cards)
        {
            Debug.Log("what the fuck");
            foreach(CardSlot cs in ch.cardSlots)
            {
                // Debug.Log("penis");
                if (cs.transform.childCount == 0) continue;
                Card card = cs.GetComponentInChildren<Card>();
                Debug.Log(card.rank);
                if (card.selected && card.rank == rank)
                {
                    pointRank += extraPoint;
                }
            }
        }
        Debug.Log(pointRank);
        Debug.Log("incoming");
        toolbox.ScorePoints(pointRank);
        // throw new System.NotImplementedException();
    }

    public override void Init()
    {
        extraPoint = 10;
        rank = new List<string>{"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"}[UnityEngine.Random.Range(0, 12)];
        Debug.LogFormat("I'm trying my best, okay? {0}", rank);
    }

    public override string GetData()
    {
        return rank;
    }
}
