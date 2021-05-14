using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MousesCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] mouses = GameObject.FindGameObjectsWithTag("Mouse");
        transform.GetComponent<Text>().text = mouses.Length.ToString();
    }
}
