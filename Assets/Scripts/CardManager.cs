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

    void Awake()
    {
        cardJSONData = JSON.Parse(cardTypes.text);
    }
    void Start()
    {
        float woaw = -2f;
        int sort = 0;
        foreach(JSONNode r in cardJSONData["ranks"])
        {
            foreach(JSONNode s in cardJSONData["suits"])
            {
                Card meow = Instantiate(cardPrefab) as Card;
                meow.SetCard(r["id"], s["id"], r["points"], r["mults"]);
                meow.transform.position = new Vector3(woaw, woaw, 0);
                meow.GetComponentInChildren<SpriteRenderer>().sortingOrder = sort;
                woaw += 0.1f;
                sort += 1;

            }
        }
        // test();
    }
}
