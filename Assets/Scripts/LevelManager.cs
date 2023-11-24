using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] buttonLevels;
    
    [Header("Level 1")]
    public GameObject[] level1;
    private int indexLevel1;
    public GameObject level1Panel;

    [Header("Level 2")]
    public GameObject[] level2;
    public AudioSource[] level2Audio;
    private int indexLevel2;
    public GameObject level2Panel;

    void Start()
    {
        indexLevel1 = 0;
        indexLevel2 = 0;
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("Level", 1) == 1)
        {
            for(int i = 0; i < buttonLevels.Length; i++)
            {
                buttonLevels[i].interactable = false;
            }
            buttonLevels[0].interactable = true;
        }
        else if(PlayerPrefs.GetInt("Level", 1) == 2)
        {
            for (int i = 0; i < buttonLevels.Length; i++)
            {
                buttonLevels[i].interactable = false;
            }
            buttonLevels[0].interactable = true;
            buttonLevels[1].interactable = true;
        }
        else if (PlayerPrefs.GetInt("Level", 1) == 3)
        {
            for (int i = 0; i < buttonLevels.Length; i++)
            {
                buttonLevels[i].interactable = false;
            }
            buttonLevels[0].interactable = true;
            buttonLevels[1].interactable = true;
            buttonLevels[2].interactable = true;
        }
        else if (PlayerPrefs.GetInt("Level", 1) == 4)
        {
            for (int i = 0; i < buttonLevels.Length; i++)
            {
                buttonLevels[i].interactable = true;
            }
        }
    }

    public void NextLevel1Button()
    {
        if (indexLevel1 >= level1.Length - 1)
        {
            Debug.Log("Finish Level 1");
            PlayerPrefs.SetInt("Level", 2);
            indexLevel1 = 0;
            for (int i = 0; i < level1.Length; i++)
            {
                level1[i].SetActive(false);
            }
            level1[0].SetActive(true);
            level1Panel.SetActive(false);
        }
        else
        {
            for (int i = 0; i < level1.Length; i++)
            {
                level1[i].SetActive(false);
            }
            indexLevel1++;
            level1[indexLevel1].SetActive(true);
            level2Panel.SetActive(false);
        }
    }

    public void NextLevel2Button()
    {

        if (indexLevel2 >= level2.Length - 1)
        {
            Debug.Log("Finish Level 2");
            PlayerPrefs.SetInt("Level", 3);
            indexLevel2 = 0;
            for (int i = 0; i < level2.Length; i++)
            {
                level2[i].SetActive(false);
            }
            level2[0].SetActive(true);
            level2Panel.SetActive(false);
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

    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }
}

