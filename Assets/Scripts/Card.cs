using UnityEngine;
using UnityEngine.U2D;

public class Card : MonoBehaviour
{
    public SpriteAtlas cards;
    private SpriteRenderer card;
    [SerializeField]
    private string _rank;
    [SerializeField]
    private string _suit;
    [SerializeField]
    private int _points;
    [SerializeField]
    private int _mults;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        card = GetComponentInChildren<SpriteRenderer>();
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
        Debug.Log(_rank + _suit);
        
    }

    public void SetSprite()
    {
        card.sprite = cards.GetSprite(_rank + _suit);
    }
    
    public void SetSprite(string name)
    {
        card.sprite = cards.GetSprite(name);
    }

    public string GetName()
    {
        return _rank + _suit;
    }
}
