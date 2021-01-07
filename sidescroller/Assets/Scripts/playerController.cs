using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {

    float moveSpeed = 20f;

    public float turnAngle = 180.0f;
    public float turnSpeed = 2.0f;
    float turnTime = 0;
    bool turn = false;
    bool invincible = false;
    bool doubleJumpOn = false;
    int doubleJumpCount = 0;


    float defaultRotationAngle;
    float currentRotationAngle;
    public bool isCollided = false;
    public Vector3 currentPosition;
    static public bool hasKey1 = false;

    void Start()
    {
        defaultRotationAngle = transform.localEulerAngles.y;
        currentRotationAngle = transform.localEulerAngles.y;
        doubleJumpCount = 0;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        doubleJumpCount = 0;
        if (collisionInfo.gameObject.name != "CastleBlue" && collisionInfo.gameObject.name != "Chest" && collisionInfo.gameObject.name != "Door" && collisionInfo.gameObject.name != "doubleJumpBlock")
        {
            isCollided = true;
        }

        if (collisionInfo.gameObject.name == "enemy1KillZone") // jump on enemy head
        {
            Destroy(collisionInfo.transform.parent.gameObject);
            jump();          
        }

        if (collisionInfo.gameObject.name == "enemy1Beak" || collisionInfo.gameObject.name == "enemy1Body" || collisionInfo.gameObject.name == "enemy1Feet" || collisionInfo.gameObject.name == "spikes" || collisionInfo.gameObject.name == "Crate") // objects that can kill
        {
            Destroy(collisionInfo.transform.parent.gameObject);
            if (invincible == false)
            {
                Death();
            }
        }

        if (collisionInfo.gameObject.name == "cloud") // bouncy cloud
        {
            rb.velocity = new Vector3(0, 14, 0);
        }

    }

    private void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.name != "CastleBlue" && collisionInfo.gameObject.name != "Chest" && collisionInfo.gameObject.name != "Door" && collisionInfo.gameObject.name != "doubleJumpBlock") // objects that are excluded
        {
            isCollided = false;
        }

        if (collisionInfo.gameObject.name == "doubleJumpBlock")
        {
            doubleJumpOn = true;
            Debug.Log(doubleJumpOn);
            Debug.Log(doubleJumpCount);
            StartCoroutine(DoubleJump());
            Destroy(collisionInfo.transform.gameObject);
        }

        if (collisionInfo.gameObject.name == "invincibleBlock")
        {
            invincible = true;
            Debug.Log(invincible);
            StartCoroutine(Invincible());
            Destroy(collisionInfo.transform.gameObject);
        }
    }


    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoveBack();
        }

        if (turnTime < 1)
        {
            turnTime += Time.deltaTime * turnSpeed;
        }

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.LerpAngle(currentRotationAngle, defaultRotationAngle + (turn ? turnAngle : 0), turnTime), transform.localEulerAngles.z);

        if (Input.GetMouseButtonDown(0)) // for 180 turns
        {           
            currentRotationAngle = transform.localEulerAngles.y;
            turnTime = 0;
            turn = !turn;
        }

        if (Input.GetKeyDown("space"))
        {
            if (isCollided == true || (doubleJumpOn == true && doubleJumpCount < 2))
            {
                jump();
                doubleJumpCount++;
            }
        }
        currentPosition = gameObject.transform.rotation.eulerAngles;
    }   

    void MoveForward()
    {
        if (Input.GetKey(KeyCode.LeftShift)) // sprint
        {
            if (rb.velocity.x < 16 && rb.velocity.x > -16) 
            {
                moveSpeed = 27f;
                rb.AddForce(transform.forward * moveSpeed);
            }
        }
        else
        {
            if (rb.velocity.x < 11 && rb.velocity.x > -11)
            {
                moveSpeed = 20f;
                rb.AddForce(transform.forward * moveSpeed);
            }
        }

    }

    void MoveBack()
    {
        if (Input.GetKey(KeyCode.LeftShift)) // sprint
        {
            if (rb.velocity.x < 16 && rb.velocity.x > -16)
            {
                moveSpeed = 27f;
                rb.AddForce(transform.forward * -moveSpeed);
            }
        }
        else
        {
            if (rb.velocity.x < 11 && rb.velocity.x > -11)
            {
                moveSpeed = 20f;
                rb.AddForce(transform.forward * -moveSpeed);
            }
        }
    }

    public Rigidbody rb;


    void jump()
    {
        rb.velocity = new Vector3(0, 14, 0);
    }

    void Death()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(1);
    }

    IEnumerator DoubleJump()
    {
        Debug.Log("on");
        yield return new WaitForSeconds(10);
        Debug.Log("off");
        doubleJumpOn = false;
    }

    IEnumerator Invincible()
    {
        Debug.Log("on");
        yield return new WaitForSeconds(10);
        Debug.Log("off");
        invincible = false;
    }
}

