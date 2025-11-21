using UnityEngine;
using SimpleJSON;
public class CardManager : MonoBehaviour
{
    public TextAsset cardTypes;
    public Card cardPrefab;
    void test()
    {
        Card meow = Instantiate(cardPrefab) as Card;
        meow.sayHi(100);
    }

    void Start()
    {
        // test();
        var woaw = JSON.Parse(cardTypes.text);
        Debug.Log(woaw["ranks"]);
    }
}
