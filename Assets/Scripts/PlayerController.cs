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

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
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
    }

    void ResetDirections()
    {
        isUp = false;
        isDown = false;
        isLeft = false;
        isRight = false;
    }
}
