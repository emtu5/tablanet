using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int round;
    public bool advanceToNextRound = false;
    public bool loss = false;
    // TODO: this is magic number shit but I wanna prototype this firstly
    public List<int> scoreRequirement;
    public List<Item> items;
    void Awake()
    {
        round = 1;
        scoreRequirement = new List<int>{0, 100, 150, 200, 300, 400, 500, 650, 800, 1000, 1200, 1400, 1600, 1900, 2200, 2500, 999999999};
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

    void Start()
    {
        
    }
    public void AdvanceRound()
    {
        round++;
    }

    public void LoseGame()
    {
        round = 1;
    }
    public void RestartScene()
    {
        SceneManager.LoadScene("Assets/Scenes/TestScene.unity");
    }
}
