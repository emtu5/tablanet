using UnityEngine;
using System;
using System.Collections.Generic;

public class Tablago : Effect
{
    public override bool IsValid()
    {
        var cards = toolbox.GetCards();
        List<int> counts = new List<int>() {0, 0, 0};
        for (int i = 0; i < cards.Count; i++)
        {
            foreach (CardSlot cs in cards[i].cardSlots)
            {
                if (cs.transform.childCount == 0) continue;
                Card card = cs.GetComponentInChildren<Card>();
                if (!card.selected) continue;
                counts[i]++
;            }
        }
        Debug.LogFormat("{0} {1} {2}", counts[0], counts[1], counts[2]);
        for (int i = 0; i < cards.Count; i++)
        {
            if (counts[i] == cards[i].cardSlots.Count) return true;
        }
        return false;
    }
    public override void Perform(string param)
    {
        toolbox.DoubleMult();
    }
}
