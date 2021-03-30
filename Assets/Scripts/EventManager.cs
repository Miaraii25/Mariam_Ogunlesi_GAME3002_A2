using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    bool TimeBasedEventActive;

    void Awake()
    {
        instance = this;
    }

    public List<Event> EventList = new List<Event>();

    public void StartEvent(int ID)
    {
        foreach (Event enet in EventList)
        {
            if(!enet.EventComplete && !enet.active && enet.TimeToComplete>0 && !TimeBasedEventActive)
            {
                enet.active = true;
                TimeBasedEventActive = true;

                StartCoroutine(Timer(enet.TimeToComplete, ID));
            }
            else if(!enet.EventComplete && !enet.active && enet.TimeToComplete <=0 )
            {
                enet.active = true;
            }
        }
    }
   
    IEnumerator Timer(float t, int ID)
    {
        float temptTime = t;
        while(TimeBasedEventActive && temptTime > 0)
        {
          yield return new WaitForSeconds(1f);
          temptTime -= 1;
          Debug.Log(temptTime);
        }

        //Deativate
        TimeBasedEventActive = false;
        DeactivateEvent(ID);
    }

    void DeactivateEvent(int ID)
    {
        EventList.Find(e => e.EventId == ID).DeactivateEvent();
        if (TimeBasedEventActive)
        {
            TimeBasedEventActive = false;
        }
        Debug.Log("Event has end");
    }

    public void UpdateEvent(int ID)
    {
        EventList.Find(e => e.EventId == ID).UpdateEvent();
    }
    public void StopTimer()
    {
        TimeBasedEventActive = false;
    }
    public bool CheckIfEventStarted(int ID)
    {
       return EventList.Find(e => e.EventId == ID).GetEventActive();
    }

    public void ResetAllEvent()
    {
        foreach(var Event in EventList)
        {
           if(Event.active)
            {
                Event.DeactivateEvent();
            }
        }
        TimeBasedEventActive = false;
    }
}
