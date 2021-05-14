using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MousesCounter : MonoBehaviour
{
    private int mousesCount = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] mouses = GameObject.FindGameObjectsWithTag("Mouse");
        mousesCount = mouses.Length;
        transform.GetComponent<Text>().text = mousesCount.ToString();
    }

    public int GetMousesCount()
    {
        return mousesCount;
    }
}
