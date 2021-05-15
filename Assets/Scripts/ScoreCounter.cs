using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private Transform scorePopUp;

    static private int score = 0;
    static private int scoreGlobal = 0;

    // Start is called before the first frame update
    void Start()
    {
        scorePopUp = GameObject.Find("Score Pop Up").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Text>().text = score.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        scorePopUp.GetComponent<Text>().text = amount.ToString();
        scorePopUp.GetComponent<Animator>().SetTrigger("PopUpTrigger");
    }
}
