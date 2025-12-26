using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RoundManager : MonoBehaviour
{
    public TMP_Text points;
    public TMP_Text mults;
    public TMP_Text hand;
    public TMP_Text total;
    public Button playButton;
    public int handsLeft = 1;

    void Awake()
    {
        playButton.GetComponentInChildren<TMP_Text>().text = String.Format("Play Hand ({0})", handsLeft);
    }

    public void ShowHandValue(int pts, int mlt) {
        int handValue = pts * mlt;
        points.text = pts.ToString();
        mults.text = mlt.ToString();
        hand.text = handValue.ToString();
    }

    public void AddToTotal() {
        total.text = (Int32.Parse(total.text) + Int32.Parse(hand.text)).ToString();
    }

    public void PlayHand()
    {
        if (handsLeft > 0)
        {
            handsLeft -= 1;
            playButton.GetComponentInChildren<TMP_Text>().text = String.Format("Play Hand ({0})", handsLeft);
        }
        if (handsLeft == 0)
        {
            playButton.interactable = false;
        }
    }
}
