using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Event
{
    public int EventId;
    public bool active;
    public bool permanentActive;
    public bool EventComplete;
    public bool restartOnNextball;
    public bool StopOnBallEnd;
    public bool resetOnComplete;
    public bool canTriggerMultiball;
    public float TimeToComplete;
    public int Score;
    public int AmountToComplete;
    public int CurrentAmount;

    // Start is called before the first frame update
    public void ResetEvent()
    {
        if (resetOnComplete)
        {
            if (permanentActive)
            {
                active = true;

            }
            else
            {
                active = false;

            }
            EventComplete = false;
            CurrentAmount = 0;

        }
    }

    public void DeactivateEvent()
    {
        active = false;
        CurrentAmount = 0;
    }

    public void UpdateEvent()
    {
        if (active && !EventComplete)
        {
            CurrentAmount++;
            CheckEventComplete();
        }
    }

    void CheckEventComplete()
    {
        if (CurrentAmount >= AmountToComplete)
        {
            EventComplete = true;
            active = false;

            if (TimeToComplete > 0)
            {
                // stop timer
                EventManager.instance.StopTimer();
            }
            if (canTriggerMultiball)
            {
                GameManager.instance.StartMultiBall();
            }

            ScoreManager.instance.AddScore(Score);
            ResetEvent();
            Debug.Log("Mission complete");
        }
    }
    public bool GetEventActive()
    {
        return active;
    }
}
