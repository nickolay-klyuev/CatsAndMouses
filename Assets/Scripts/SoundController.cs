using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip levelCompleteSound;

    private MousesCounter mousesCounter;
    private AudioSource audioSource;

    private bool isLevelCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mousesCounter = GameObject.FindObjectOfType<MousesCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mousesCounter.GetMousesCount() == 0 && !isLevelCompleted)
        {
            isLevelCompleted = true;
            audioSource.Stop();
            audioSource.clip = levelCompleteSound;
            audioSource.loop = false;
            audioSource.Play();
        }
    }
}
