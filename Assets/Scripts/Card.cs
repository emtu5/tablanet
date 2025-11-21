using UnityEngine;
using UnityEngine.U2D;

public class Card : MonoBehaviour
{
    public SpriteAtlas cards;
    private SpriteRenderer card;
    private string _rank;
    private string _suit;

    private int _points;
    private int _mults;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        card = GetComponentInChildren<SpriteRenderer>();
        card.sprite = cards.GetSprite("Ac");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sayHi(int x)
    {
        _points = x;
        Debug.Log("Hiiiii");
        Debug.Log(_points);
    }

    public void SetCard(string rank, string suit, int points, int mults)
    {
        _rank = rank;
        _suit = suit;
        _points = points;
        _mults = mults;
    }
}
