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
    public bool selectable = false;
    private bool _selected = false;

    void Awake()
    {
        card = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCard(string rank, string suit, int points, int mults)
    {
        _rank = rank;
        _suit = suit;
        _points = points;
        _mults = mults;   
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

    public void Select()
    {
        _selected = !_selected;
        if (_selected)
        {
            transform.localPosition = new Vector3(0f, 0.2f, 0f);
        }
        else
        {
            transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }
}
