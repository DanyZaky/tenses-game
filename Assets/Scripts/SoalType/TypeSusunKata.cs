using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeSusunKata : MonoBehaviour
{
    public TMP_InputField jawaban;
    public string[] words;
    public GameObject[] wordObjects;

    public void onClickWord(int index)
    {
        wordObjects[index].SetActive(false);
        jawaban.text += words[index] + " ";
        
    }

    public void ResetWords()
    {
        for(int i = 0; i < wordObjects.Length; i++)
        {
            wordObjects[i].SetActive(true);
        }

        jawaban.text = "";
    }
}
