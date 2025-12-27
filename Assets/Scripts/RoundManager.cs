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
    public int rnd;
    public int scoreReq;
    public int ptns;
    public int mult;
    public int handVal;
    public int totl;
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
        // Debug.Log(GameManager.Instance.round);
        rnd = GameManager.Instance.round;
        round.text = rnd.ToString();
        Debug.Log("mrow");
        
        // Debug.Log(round.text);
        scoreReq = GameManager.Instance.scoreRequirement[rnd];
        scoreRequirement.text = scoreReq.ToString();
    }

    public void ShowHandValue(int pts, int mlt) {
        ptns = pts;
        mult = mlt;
        handVal = ptns * mult;
        points.text = pts.ToString();
        mults.text = mlt.ToString();
        hand.text = handVal.ToString();
    }

    public void AddToTotal() {
        totl += handVal;
        total.text = totl.ToString();
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
        if (totl >= scoreReq) // win
        {
            playButton.interactable = false;
            GameManager.Instance.advanceToNextRound = true;
            GameManager.Instance.AdvanceRound();
            winPanel.GetComponentInChildren<TMP_Text>().text = String.Format("Round {0} Complete!", rnd);
            winPanel.SetActive(true);
        }
        else if (handsLeft == 0) // lose
        {
            GameManager.Instance.advanceToNextRound = true;
            GameManager.Instance.LoseGame();
            losePanel.GetComponentInChildren<TMP_Text>().text = String.Format("Game Over! Final Round: {0}", rnd);
            losePanel.SetActive(true);
        }
    }
}
