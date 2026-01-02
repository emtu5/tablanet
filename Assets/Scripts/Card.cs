using UnityEngine;
using UnityEngine.U2D;
using System;
using System.Collections.Generic;
using System.Linq;

public class Card : MonoBehaviour
{
    public SpriteAtlas cards;
    private SpriteRenderer card;
    public string rank {get; private set;}
    public string suit {get; private set;}
    public int points {get; private set;}
    public int mults {get; private set;}
    public List<int> value;
    public int extraPoints = 0;
    public int extraMults = 0;
    public bool selectable = false;
    public bool selected = false;

    void Awake()
    {
        card = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCard(string _rank, string _suit, List<int> _value, int _points, int _mults)
    {
        rank = _rank;
        suit = _suit;
        value = _value;
        points = _points;
        mults = _mults;
    }

    public void SetSprite()
    {
        card.sprite = cards.GetSprite(rank + suit);
    }
    
    public void SetSprite(string name)
    {
        card.sprite = cards.GetSprite(name);
    }

    public string GetName()
    {
        return rank + suit;
    }

    public void Select()
    {
        selected = !selected;
        if (selected)
        {
            transform.localPosition = new Vector3(0f, 0.2f, 0f);
        }
        else
        {
            transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }

    public void Gwah()
    {
        Debug.Log("Gwah");
    }
}
