using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateControl : MonoBehaviour {

    public float timeGap = 1f;
    public Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        pause();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name != "Player")
        {
            Debug.Log("crate");
            rb.velocity = new Vector3(0, 10, 0);
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    IEnumerator pause()
    {
        yield return new WaitForSeconds(timeGap);
    }
    
}
