using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletedController : MonoBehaviour
{
    private MousesCounter mousesCounter;

    // Start is called before the first frame update
    void Start()
    {
        mousesCounter = GameObject.FindObjectOfType<MousesCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mousesCounter.GetMousesCount() == 0)
        {
            GetComponent<Animator>().SetTrigger("CompletedLevelTrigger");
        }
    }
}
