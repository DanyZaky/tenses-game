using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeEssay : MonoBehaviour
{
    public TMP_InputField jawabanInput;

    public void Jawaban()
    {
        SoalHandler.instance.currentJawaban[SoalHandler.instance.currentIndex] = jawabanInput.text.ToLower();

    }

    public void JawabanLevel4()
    {
        Level4SoalHandler.instance.currentJawaban[Level4SoalHandler.instance.currentIndex] = jawabanInput.text.ToLower();
    }
}
