using UnityEngine;

public class CardManager : MonoBehaviour
{
    public Card cardPrefab;
    void test()
    {
        Card meow = Instantiate(cardPrefab) as Card;
        meow.sayHi(100);
    }

    void Start()
    {
        test();
    }
}
