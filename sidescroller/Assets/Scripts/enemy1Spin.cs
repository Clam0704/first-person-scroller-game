using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Spin : MonoBehaviour {

    public float spinSpeed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, spinSpeed, 0);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }
}
