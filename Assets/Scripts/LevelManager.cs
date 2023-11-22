using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level 1")]
    public GameObject[] level1;
    private int indexLevel1;

    [Header("Level 2")]
    public GameObject[] level2;
    public AudioSource[] level2Audio;
    private int indexLevel2;

    void Start()
    {
        indexLevel1 = 0;
        indexLevel2 = 0;
    }

    public void NextLevel1Button()
    {
        
        if (indexLevel1 >= level1.Length - 1)
        {
            Debug.Log("Finish Level 1");
        }
        else
        {
            for (int i = 0; i < level1.Length; i++)
            {
                level1[i].SetActive(false);
            }
            indexLevel1++;
            level1[indexLevel1].SetActive(true);
        }
    }

    public void NextLevel2Button()
    {

        if (indexLevel2 >= level2.Length - 1)
        {
            Debug.Log("Finish Level 2");
        }
        else
        {
            for (int i = 0; i < level2.Length; i++)
            {
                level2[i].SetActive(false);
            }
            indexLevel2++;
            if (indexLevel2 != 0 && indexLevel2 != 1)
            {
                level2Audio[indexLevel2].Play();
            }
            level2[indexLevel2].SetActive(true);
        }
    }
}

