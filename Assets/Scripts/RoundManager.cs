using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RoundManager : MonoBehaviour
{
    public TMP_Text round;
    public TMP_Text scoreRequirement;
    public TMP_Text points;
    public TMP_Text mults;
    public TMP_Text hand;
    public TMP_Text total;
    public Button playButton;
    public GameObject winPanel;
    public GameObject losePanel;
    public int handsLeft = 5;

    void Awake()
    {
        playButton.GetComponentInChildren<TMP_Text>().text = String.Format("Play Hand ({0})", handsLeft);
    }
    
    void Start()
    {
        Debug.Log(GameManager.Instance.round);
        round.text = GameManager.Instance.round.ToString();
        Debug.Log("mrow");
        
        Debug.Log(round.text);
        scoreRequirement.text = GameManager.Instance.scoreRequirement[Int32.Parse(round.text)].ToString();
    }

    public void ShowHandValue(int pts, int mlt) {
        int handValue = pts * mlt;
        points.text = pts.ToString();
        mults.text = mlt.ToString();
        hand.text = handValue.ToString();
    }

    public void AddToTotal() {
        total.text = (Int32.Parse(total.text) + Int32.Parse(hand.text)).ToString();
        CheckWin();
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
            CheckWin();
        }
    }

    public void CheckWin()
    {
        if (Int32.Parse(total.text) >= Int32.Parse(scoreRequirement.text)) // win
        {
            playButton.interactable = false;
            GameManager.Instance.advanceToNextRound = true;
            GameManager.Instance.AdvanceRound();
            winPanel.GetComponentInChildren<TMP_Text>().text = String.Format("Round {0} Complete!", round.text);
            winPanel.SetActive(true);
        }
        else if (handsLeft == 0) // lose
        {
            GameManager.Instance.advanceToNextRound = true;
            GameManager.Instance.LoseGame();
            losePanel.GetComponentInChildren<TMP_Text>().text = String.Format("Game Over! Final Round: {0}", round.text);
            losePanel.SetActive(true);
        }
    }
}
