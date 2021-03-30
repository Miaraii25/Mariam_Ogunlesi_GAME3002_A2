using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int startBallAmount = 10;
    int currentBallAmount;
    int activeBallOnPlay;

    public GameObject ballPrefab;
    public Transform SpawnPoint;
    public Transform MultiSpawnPoint;

    bool GameStarted;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ResetGame();

    }
    void ResetGame()
    {
        currentBallAmount = startBallAmount;
        UIManager.instance.UpdateBallText(currentBallAmount);
        EventManager.instance.ResetAllEvent();
        CreateNewBall();
    }

    public void CreateNewBall()
    {
        if(activeBallOnPlay == 0 && currentBallAmount>0)
        {
            Instantiate(ballPrefab, SpawnPoint.position, Quaternion.identity);
            UpdateBallOnPlay(+1);
            currentBallAmount--;
            UIManager.instance.UpdateBallText(currentBallAmount);

        }
        else
        {
            //Game Over
            Debug.Log("GAME OVER");
        }
    }

    public void StartMultiBall()
    {
        StartCoroutine(Multiball());
    }

    public void UpdateBallOnPlay(int Amount)
    {
        activeBallOnPlay += Amount;
    }

    IEnumerator Multiball()
    {
        int Amount = 3;
        while (Amount > 0)
        {
            Instantiate(ballPrefab, MultiSpawnPoint.position, Quaternion.identity);
           UpdateBallOnPlay(+1);
            Amount--;
            yield return new WaitForSeconds(1f);
        }
    }
}
