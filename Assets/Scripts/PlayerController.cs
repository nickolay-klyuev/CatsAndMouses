using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10f;
    
    private bool isUp = false;
    private bool isDown = false;
    private bool isLeft = false;
    private bool isRight = false;

    private Rigidbody2D rigidBody;
    private MousesCounter mousesCounter;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        mousesCounter = GameObject.FindObjectOfType<MousesCounter>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Down"))
        {
            ResetDirections();
            isDown = true;
        }
        if (Input.GetButton("Up"))
        {
            ResetDirections();
            isUp = true;
        }
        if (Input.GetButton("Left"))
        {
            ResetDirections();
            isLeft = true;
        }
        if (Input.GetButton("Right"))
        {
            ResetDirections();
            isRight = true;
        }

        if (isUp)
        {
            rigidBody.velocity = new Vector2(0, playerSpeed);
        }
        else if (isDown)
        {
            rigidBody.velocity = new Vector2(0, -playerSpeed);
        }
        if (isLeft)
        {
            rigidBody.velocity = new Vector2(-playerSpeed, 0);
        }
        if (isRight)
        {
            rigidBody.velocity = new Vector2(playerSpeed, 0);
        }

        if (mousesCounter.GetMousesCount() == 0)
        {
            rigidBody.velocity = new Vector2(0, 0);
            animator.enabled = false;
        }
    }

    void ResetDirections()
    {
        isUp = false;
        isDown = false;
        isLeft = false;
        isRight = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<MouseController>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
