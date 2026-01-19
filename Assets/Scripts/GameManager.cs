using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Vector3 _starting_position;
    public static GameManager Instance;
    public int round;
    public bool paused = false;
    public bool loss = false;
    // TODO: this is magic number shit but I wanna prototype this firstly
    public List<int> scoreRequirement;
    public List<Item> items;
    void Awake()
    {
        _starting_position = new Vector3(-8f, 4f, 0f);
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

    void Update()
    {
        ArrangeItems();
    }

    public void AdvanceRound()
    {
        GameManager.Instance.round++;
    }

    public void LoseGame()
    {
        GameManager.Instance.round = 1;
    }

    public void RestartScene()
    {
        GameManager.Instance.paused = false;
        SceneManager.LoadScene("Assets/Scenes/TestScene.unity");
    }

    public void GoToShop()
    {
        Debug.Log("hello");
        SceneManager.LoadScene("Assets/Scenes/Shop.unity");
        Debug.Log("hi");
    }

    public void GoToMenu() {
        SceneManager.LoadScene("Assets/Scenes/Menu.unity");
        Destroy(gameObject);
    }

    public void ArrangeItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.position = _starting_position + i * new Vector3(1.2f, 0f, 0f);
        }
    }
}
