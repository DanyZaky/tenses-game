using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypePilgan : MonoBehaviour
{
    public Button[] answerButtons;

    public void JawabanSalah(int index)
    {
        SoalHandler.instance.currentJawaban[SoalHandler.instance.currentIndex] = "Salah";

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
        }

        answerButtons[index].interactable = false;
    }

    public void JawabanBenar(int index)
    {
        SoalHandler.instance.currentJawaban[SoalHandler.instance.currentIndex] = SoalHandler.instance.currentKunciLevel3[SoalHandler.instance.currentIndex];

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
        }

        answerButtons[index].interactable = false;
    }

    public void JawabanSalahLevel4(int index)
    {
        Level4SoalHandler.instance.currentJawaban[Level4SoalHandler.instance.currentIndex] = "Salah";

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
        }

        answerButtons[index].interactable = false;
    }

    public void JawabanBenarLevel4(int index)
    {
        Level4SoalHandler.instance.currentJawaban[Level4SoalHandler.instance.currentIndex] = Level4SoalHandler.instance.currentKunciLevel3[Level4SoalHandler.instance.currentIndex];

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
        }

        answerButtons[index].interactable = false;
    }
}
