using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestData : MonoBehaviour
{
    void Start()
    {
        //PlayerPrefs.SetString("Huruf", "ABCD");
        string huruf = PlayerPrefs.GetString("Huruf");
        Debug.Log(huruf);
    }

    void Update()
    {
        
    }
}
