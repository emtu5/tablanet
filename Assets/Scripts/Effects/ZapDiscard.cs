using UnityEngine;
using System;
using System.Collections.Generic;

public class ZapDiscard : Effect
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
                counts[i]++;
;            }
        }
        int nonzeroes = 0;
        foreach (int n in counts)
        {
            if (n != 0) nonzeroes++;
        }
        return nonzeroes == 1;
    }

    public override void Perform()
    {
        toolbox.Discard();
    }
}
