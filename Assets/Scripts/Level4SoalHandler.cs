using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level4SoalHandler : MonoBehaviour
{
    public static Level4SoalHandler  instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject nextButton, prevButton, finishButton;

    public GameObject[] soalDisplay;
    public string[] kunciLevel3;
    public string[] currentKunciLevel3;
    public string[] currentJawaban;
    public int[] soalIndex;
    public int currentIndex;
    void Start()
    {
        soalIndex = GenerateRandomIntArray(10, 0, 44);

        for (int i = 0; i < currentKunciLevel3.Length; i++)
        {
            currentKunciLevel3[i] = kunciLevel3[soalIndex[i]];
        }

        currentIndex = 0;
        for (int i = 0; i < soalDisplay.Length; i++)
        {
            soalDisplay[i].SetActive(false);
        }
        soalDisplay[soalIndex[currentIndex]].SetActive(true);
    }

    private void Update()
    {
        if (currentIndex <= 0)
        {
            prevButton.SetActive(false);
            nextButton.SetActive(true);
            finishButton.SetActive(false);
        }
        else if (currentIndex >= 9)
        {
            prevButton.SetActive(true);
            nextButton.SetActive(false);
            finishButton.SetActive(true);
        }
        else
        {
            prevButton.SetActive(true);
            nextButton.SetActive(true);
            finishButton.SetActive(false);
        }

        if (CheckArrayValues(currentJawaban))
        {
            finishButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            finishButton.GetComponent<Button>().interactable = false;
        }

        Debug.Log(CheckArrayValues(currentJawaban));
    }

    int[] GenerateRandomIntArray(int length, int minValue, int maxValue)
    {
        if (length > (maxValue - minValue + 1))
        {
            Debug.LogError("Panjang array tidak valid untuk rentang nilai yang diberikan.");
            return null;
        }

        List<int> values = new List<int>();
        for (int i = minValue; i <= maxValue; i++)
        {
            values.Add(i);
        }

        int[] randomArray = new int[length];
        for (int i = 0; i < length; i++)
        {
            int randomIndex = Random.Range(0, values.Count);
            randomArray[i] = values[randomIndex];
            values.RemoveAt(randomIndex);
        }

        return randomArray;
    }

    public void NextSoal()
    {
        currentIndex++;
        for (int i = 0; i < soalDisplay.Length; i++)
        {
            soalDisplay[i].SetActive(false);
        }
        soalDisplay[soalIndex[currentIndex]].SetActive(true);
    }

    public void PrevSoal()
    {
        currentIndex--;
        for (int i = 0; i < soalDisplay.Length; i++)
        {
            soalDisplay[i].SetActive(false);
        }
        soalDisplay[soalIndex[currentIndex]].SetActive(true);
    }

    public void FinishButton()
    {
        PlayerPrefs.SetInt("Level", 4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    bool CheckArrayValues(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (string.IsNullOrEmpty(array[i]) || array[i] == "")
            {
                return false;
            }
        }
        return true;
    }
}
