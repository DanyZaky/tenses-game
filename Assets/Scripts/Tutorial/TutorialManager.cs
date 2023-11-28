using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] slides;


    public void OnClickButtonNext(int index)
    {
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].SetActive(false);
        }

        slides[index].SetActive(true);
    }
}
