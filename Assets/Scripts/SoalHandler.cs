using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoalHandler : MonoBehaviour
{
    public static SoalHandler instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject nextButton, prevButton;

    public GameObject[] soalDisplay;
    public string[] kunciLevel3;
    public string[] currentKunciLevel3;
    public string[] currentJawaban;
    public int[] soalIndex;
    public int currentIndex;
    void Start()
    {
        soalIndex = GenerateRandomIntArray(10, 0, 14);

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
        if(currentIndex <= 0)
        {
            prevButton.SetActive(false);
            nextButton.SetActive(true);
        }
        else if(currentIndex >= 9)
        {
            prevButton.SetActive(true);
            nextButton.SetActive(false);
        }
        else
        {
            prevButton.SetActive(true);
            nextButton.SetActive(true);
        }
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
}
