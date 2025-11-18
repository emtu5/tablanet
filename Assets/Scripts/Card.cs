using UnityEngine;
using System;
public class Card : MonoBehaviour
{
    private String rank;
    private String suit;
    private int points;
    private int mults;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sayHi(int x)
    {
        points = x;
        Debug.Log("Hiiiii");
        Debug.Log(points);
    }
}
