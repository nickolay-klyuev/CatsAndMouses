using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float mouseSpeed = 8f;
    public float minRangeToPlayer = 2f;

    private GameObject player;
    private Rigidbody2D rigidBody;

    private bool isCharging = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rigidBody = GetComponent<Rigidbody2D>();

        ChangeDirectionRandom(mouseSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        float xRangeToPlayer = Mathf.Abs(player.transform.position.x - transform.position.x);
        float yRangeToPlayer = Mathf.Abs(player.transform.position.y - transform.position.y);

        if (xRangeToPlayer <= minRangeToPlayer || yRangeToPlayer <= minRangeToPlayer)
        {
            if (!isCharging)
            {
                isCharging = true;
                ChangeDirectionRandom(mouseSpeed * 3);
            }
        }
        else
        {
            isCharging = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Wall")
        {
            ChangeDirectionRandom(mouseSpeed);
        }
    }

    void ChangeDirectionRandom(float speed)
    {
        int random = Random.Range(1, 4);
        Vector2 direction = new Vector2(0, 0);

        switch(random)
        {
            case 1:
                direction = new Vector2(0, speed);
                break;
            case 2:
                direction = new Vector2(0, -speed);
                break;
            case 3:
                direction = new Vector2(speed, 0);
                break;
            case 4:
                direction = new Vector2(-speed, 0);
                break;
        }

        rigidBody.velocity = direction;
    }
}
