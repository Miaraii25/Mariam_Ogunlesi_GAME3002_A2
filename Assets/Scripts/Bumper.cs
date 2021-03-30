using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] float Pow = 1f;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void OnCollisionEnter(Collision col)
    {
        foreach(ContactPoint contact in col.contacts)
        {
            contact.otherCollider.attachedRigidbody.AddForce(-1 * contact.normal * Pow, ForceMode.Impulse);
        }
        if(anim != null)
        {
            anim.SetTrigger("activate");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
