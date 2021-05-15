using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    private ScoreCounter scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = GameObject.FindObjectOfType<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Text>().text = scoreCounter.GetScore().ToString();
    }
}
