using UnityEngine;
using UnityEngine.U2D;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class Card : MonoBehaviour
{
    public SpriteAtlas cards;
    private SpriteRenderer card;
    public string rank {get; private set;}
    public string suit {get; private set;}
    public int points {get; private set;}
    public int mults {get; private set;}
    public List<int> value;
    public int currentValue;
    public int extraPoints = 0;
    public int extraMults = 0;
    public bool selectable = false;
    public bool selected = false;
    public Animator animator;
    public SpriteRenderer blue;
    public SpriteRenderer red;
    public TMP_Text pt;
    public TMP_Text mt;
    public AudioSource score;
    public AudioSource click;

    void Awake()
    {
        card = GetComponentInChildren<SpriteRenderer>();
        currentValue = -1;
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
        click.Play();
        if (selected)
        {
            transform.localPosition = new Vector3(0f, 0.2f, 0f);
        }
        else
        {
            transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }

    // public void Gwah()
    // {
    //     Debug.Log("Gwah");
    // }

    public void Score()
    {
        score.Play();
        pt.text = currentValue.ToString();
        mt.text = mults.ToString();
        animator.SetTrigger("Scoring");
    }

    public int GetValue()
    {
        if (currentValue == -1)
        {
            currentValue = value[0];
        }
        return currentValue;
    }

    public string GetTooltip() {
        return String.Format("{0}{1}, Values: [{2}]", rank, suit, String.Join(", ", value));
    }
}
