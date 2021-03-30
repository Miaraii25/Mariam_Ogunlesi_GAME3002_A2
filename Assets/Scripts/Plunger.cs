using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Plunger : MonoBehaviour
{
  
    float Pow;
    float maxPow = 2f;
    float PowCountPerTick = 1;

    Rigidbody ballRb;
    ContactPoint contact;
    bool Readyball;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Readyball)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if(Pow <= maxPow)
                {
                    Pow += PowCountPerTick * Time.deltaTime;
                }
                Debug.Log(Pow);
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (ballRb!=null)
            {
                ballRb.AddForce(-1 * Pow * contact.normal, ForceMode.Impulse);
            }
        }
    }
    
    void OnCollisionEnter(Collision col)
    {
        Readyball = true;
        Pow = 0f;
        contact = col.contacts[0];
        ballRb = contact.otherCollider.attachedRigidbody;
    }

    void OnCollisionExit(Collision col )
    {
        Readyball = false;
        ballRb = null;
    }
}
