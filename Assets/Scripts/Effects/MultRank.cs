using UnityEngine;

public class MultRank : Effect
{
    public int extraMult = 2;
    public string rank;
    public override void Perform()
    {
        Debug.Log("goober!");
        int multRank = 0;
        var cards = toolbox.GetCards();
        Debug.Log(cards);
        foreach (CardHolder ch in cards)
        {
            foreach(CardSlot cs in ch.cardSlots)
            {
                if (cs.transform.childCount == 0) continue;
                Card card = cs.GetComponentInChildren<Card>();
                Debug.Log(card);
                if (card.selected && card.rank == rank)
                {
                    multRank += extraMult;
                }
            }
        }
        Debug.Log(multRank);
        Debug.Log("incoming");
        toolbox.ScoreMult(multRank);
        // throw new System.NotImplementedException();
    }

    void Start()
    {
        Perform();
    }
}
