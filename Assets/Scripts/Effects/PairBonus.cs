using UnityEngine;
using System;
using System.Collections.Generic;
public class PairBonus : Effect
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
        int ones = 0, zeroes = 0;
        Debug.LogFormat("{0} {1} {2}", counts[0], counts[1], counts[2]);
        foreach (int n in counts)
        {
            if (n == 1) ones++;
            if (n == 0) zeroes++;
        }
        // Debug.LogFormat("{0} {1} {2}", counts[0], counts[1], counts[2]);
        return ones == 2 && zeroes == 1;
    }

    public override void Perform()
    {
        toolbox.ScoreMult(6);
    }
}
