using UnityEngine;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int round = 0;
    public bool advanceToNextRound;
    // TODO: this is magic number shit but I wanna prototype this firstly
    public List<int> scoreRequirement = new List<int>{0, 100, 150, 200, 300, 400, 500, 650, 800, 1000, 1200, 1400, 1600, 1900, 2200, 2500, 999999999};
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
