using UnityEngine;
using SimpleJSON;
public class CardManager : MonoBehaviour
{
    public TextAsset cardTypes;
    public Card cardPrefab;
    JSONNode cardJSONData;
    void test()
    {
        Card meow = Instantiate(cardPrefab) as Card;
        meow.SetCard("2", "c", cardJSONData["ranks"]["2"]["points"], cardJSONData["ranks"]["2"]["mults"]);
    }

    void Start()
    {
        // test();
        cardJSONData = JSON.Parse(cardTypes.text);
        test();
    }
}
