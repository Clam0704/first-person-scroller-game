using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icicleControl : MonoBehaviour
{
    public Rigidbody rigidbody;
    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name == "Player")
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

}
