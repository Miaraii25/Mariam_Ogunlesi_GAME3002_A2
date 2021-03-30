using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text BallAmountText, ScoreText;

    void Awake()
    {
        instance = this;
    }


    public void UpdateBallText(int Amount)
    {
        BallAmountText.text = "Balls:" + Amount;
    }

    public void UpdatescoreText(int Amount)
    {
        ScoreText.text = "Score:" + Amount;
    }

}
