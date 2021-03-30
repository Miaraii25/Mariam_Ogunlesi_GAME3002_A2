using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    int Score;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UIManager.instance.UpdatescoreText(Score);

    }

    public int ReadScore()
    {
        return Score;
    }

    public void AddScore(int Amount)
    {
        Score += Amount;
        UIManager.instance.UpdatescoreText(Score);
    }
    
}
