using UnityEngine;
using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
public class Deck : MonoBehaviour
{
    // TODO: deck data should be loaded somewhere else (no persistent data yet)
    public TextAsset cardTypes;
    JSONNode cardJSONData;
    public Card cardPrefab;
    public List<Card> deck;

    float basePosition = 0f;
    float deckStep = 0.02f;
    // https://stackoverflow.com/questions/273313/randomize-a-listt

    static System.Random rng = new System.Random();
    void InitializeDeckData()
    {
        cardJSONData = JSON.Parse(cardTypes.text);
    }

    void InitializeDeck()
    {
        foreach(JSONNode r in cardJSONData["ranks"])
        {
            foreach(JSONNode s in cardJSONData["suits"])
            {
                Card c = Instantiate(cardPrefab, gameObject.transform) as Card;
                var values = new List<int>();
                foreach(JSONNode val in r["value"].AsArray)
                    values.Add(val.AsInt);
                c.SetCard(r["id"], s["id"], values, r["points"], r["mults"]);
                c.SetSprite();
                deck.Add(c);
            }
        }
    }

    void ShuffleDeck()
    {
        int n = deck.Count;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            Card value = deck[k];
            deck[k] = deck[n];
            deck[n] = value;
        }
    }

    void LayerCards()
    {
        float cardPosition = basePosition;
        int sort = 0;
        foreach (Card c in deck)
        {
            c.transform.localPosition = new Vector3(cardPosition, cardPosition, 0);
            c.GetComponentInChildren<SpriteRenderer>().sortingOrder = sort;
            cardPosition += deckStep;
            sort += 1;
        }
    }

    void Awake()
    {
        InitializeDeckData();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void CreateDeck()
    {
        InitializeDeck();
        ShuffleDeck();
        LayerCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
