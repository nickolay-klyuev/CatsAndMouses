using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10f;
    private float speedOffSet = 5f;

    [SerializeField] private bl_Joystick joystick;
    
    private bool isUp = false;
    private bool isDown = false;
    private bool isLeft = false;
    private bool isRight = false;

    private bool gameOver = false;

    private Rigidbody2D rigidBody;
    private MousesCounter mousesCounter;
    private Animator animator;
    private AudioSource audioSource;
    private ScoreCounter scoreCounter;

    private int scoreToAdd = 100;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        mousesCounter = GameObject.FindObjectOfType<MousesCounter>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        scoreCounter = GameObject.FindObjectOfType<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Down"))
        {
            Down();
        }
        if (Input.GetButton("Up"))
        {
            Up();
        }
        if (Input.GetButton("Left"))
        {
            Left();
        }
        if (Input.GetButton("Right"))
        {
            Right();
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
            gameOver = true;
        }
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.identity;

        if (!gameOver)
        {
            transform.Translate(new Vector2(Time.deltaTime * playerSpeed * joystick.Horizontal / speedOffSet, Time.deltaTime * playerSpeed * joystick.Vertical / speedOffSet));
        }
    }

    void ResetDirections()
    {
        isUp = false;
        isDown = false;
        isLeft = false;
        isRight = false;
    }

    public void Up()
    {
        ResetDirections();
        isUp = true;
    }

    public void Down()
    {
        ResetDirections();
        isDown = true;
    }

    public void Left()
    {
        ResetDirections();
        isLeft = true;
    }

    public void Right()
    {
        ResetDirections();
        isRight = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<MouseController>() != null)
        {
            audioSource.Play();
            animator.SetTrigger("HitTrigger");
            scoreCounter.AddScore(scoreToAdd);
            scoreToAdd *= 2;
            Invoke("DivScoreToAdd", 1f);
            Destroy(collision.gameObject);
            playerSpeed += .2f;
        }
    }

    void DivScoreToAdd()
    {
        scoreToAdd /= 2;
    }
}
