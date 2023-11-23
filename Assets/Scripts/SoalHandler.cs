using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoalHandler : MonoBehaviour
{
    public string[] kunciLevel3;
    public string[] currentKunciLevel3;
    public int[] soalIndex;
    void Start()
    {
        soalIndex = GenerateRandomIntArray(10, 1, 15);

        for (int i = 0; i < currentKunciLevel3.Length; i++)
        {
            currentKunciLevel3[i] = kunciLevel3[soalIndex[i]-1];
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
}
