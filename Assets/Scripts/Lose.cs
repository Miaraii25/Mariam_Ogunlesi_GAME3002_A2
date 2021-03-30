using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
        EventManager.instance.ResetAllEvent();
        GameManager.instance.UpdateBallOnPlay(-1);
        GameManager.instance.CreateNewBall();
    }
}
