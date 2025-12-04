using UnityEngine;
using TMPro;
using System;

public class RoundManager : MonoBehaviour
{
    public TMP_Text points;
    public TMP_Text mults;
    public TMP_Text hand;
    public TMP_Text total;

    public void ShowHandValue(int pts, int mlt) {
        int handValue = pts * mlt;
        points.text = pts.ToString();
        mults.text = mlt.ToString();
        hand.text = handValue.ToString();
    }

    public void AddToTotal() {
        total.text = (Int32.Parse(total.text) + Int32.Parse(hand.text)).ToString();
    }
}
