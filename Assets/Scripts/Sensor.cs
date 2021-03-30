using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    // Trigger to start event
    public bool isStarter;
    public bool isCounter;

    // Event Id to trigger
    public int triggerId;

    void OnTriggerEnter(Collider col)
    {
        bool startedAlready = EventManager.instance.CheckIfEventStarted(triggerId);
        if (isStarter)
        {
            EventManager.instance.StartEvent(triggerId);
        }
        if (isCounter && startedAlready)
        {
            EventManager.instance.UpdateEvent(triggerId);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        bool startedAlready = EventManager.instance.CheckIfEventStarted(triggerId);

        if (isStarter && startedAlready)
        {
            EventManager.instance.StartEvent(triggerId);
        }
        if (isCounter)
        {
            EventManager.instance.UpdateEvent(triggerId);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color32(0, 0, 255, 125);
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
    }
}
