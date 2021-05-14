using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float mouseSpeed = 8f;

    private GameObject player;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rigidBody = GetComponent<Rigidbody2D>();

        ChangeDirectionRandom();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.tag);
        if (collision.transform.tag == "Wall")
        {
            ChangeDirectionRandom();
        }
    }

    void ChangeDirectionRandom()
    {
        int random = Random.Range(1, 4);
        Vector2 direction = new Vector2(0, 0);

        switch(random)
        {
            case 1:
                direction = new Vector2(0, mouseSpeed);
                break;
            case 2:
                direction = new Vector2(0, -mouseSpeed);
                break;
            case 3:
                direction = new Vector2(mouseSpeed, 0);
                break;
            case 4:
                direction = new Vector2(-mouseSpeed, 0);
                break;
        }

        rigidBody.velocity = direction;
    }
}
