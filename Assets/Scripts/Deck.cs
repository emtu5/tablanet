using UnityEngine;
using SimpleJSON;
using System;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
    // TODO: deck data should be loaded somewhere else (no persistent data yet)
    public TextAsset cardTypes;
    JSONNode cardJSONData;
    public Card cardPrefab;
    public List<Card> deck;

    float basePosition = -2f;
    float deckStep = 0.02f;
    // https://stackoverflow.com/questions/273313/randomize-a-listt

    static System.Random rng = new System.Random();
    void InitializeDeckData()
    {
        cardJSONData = JSON.Parse(cardTypes.text);
    }

    void InitializeDeck()
    {
        float cardPosition = basePosition;
        int sort = 0;
        foreach(JSONNode r in cardJSONData["ranks"])
        {
            foreach(JSONNode s in cardJSONData["suits"])
            {
                Card c = Instantiate(cardPrefab, gameObject.transform) as Card;
                c.SetCard(r["id"], s["id"], r["points"], r["mults"]);
                c.SetSprite("BackRed");
                c.transform.position = new Vector3(cardPosition, cardPosition, 0);
                c.GetComponentInChildren<SpriteRenderer>().sortingOrder = sort;
                deck.Add(c);
                cardPosition += deckStep;
                sort += 1;
            }
        }
    }

    void ShuffleDeck()
    {
        // deck.Shuffle(); // pray
        int n = deck.Count;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            Card value = deck[k];
            deck[k] = deck[n];
            deck[n] = value;
        }
    }


    void Awake()
    {
        InitializeDeckData();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeDeck();
        ShuffleDeck();
        foreach (Card card in deck)
        {
            Debug.Log(card.GetName());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
