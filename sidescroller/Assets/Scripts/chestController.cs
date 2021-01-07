using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestController : MonoBehaviour {

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.name == "Player")
        {
            gameObject.GetComponent<Animator>().Play("ChestOpen");
        }
    }

    private bool enter = false;
    public bool ShivaEnter;
    private GameObject player;
    private Animator anim;

    // Use this for initialization
  void Start () {
  }

  // Update is called once per frame
  void Update () {
    anim = GetComponent<Animator>();
  }

  void OnTriggerEnter (Collider other)
        {
        if (other.gameObject.name == "Player")
        {
            anim.Play("Chest");
            playerController.hasKey1 = true;
            enter = true;
        }
  }
    void OnGUI()
    {
        if (enter)
        {
            // GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), "Received Key");
        }
    }
}


