using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypePilgan : MonoBehaviour
{
    public Button[] answerButtons; // Mendeklarasikan array tombol jawaban.

    public void JawabanSalah(int index)
    {
        Level4SoalHandler.instance.currentJawaban[Level4SoalHandler.instance.currentIndex] = "Salah"; // Menetapkan nilai "Salah" ke array currentJawaban pada indeks saat ini.
        // Mengaktifkan kembali interaktabilitas semua tombol jawaban.
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
        }
        // Menonaktifkan interaktabilitas tombol jawaban yang dipilih.
        answerButtons[index].interactable = false;
    }

    public void JawabanBenar(int index)
    {
        Level4SoalHandler.instance.currentJawaban[Level4SoalHandler.instance.currentIndex] = Level4SoalHandler.instance.currentKunciLevel4[Level4SoalHandler.instance.currentIndex]; // Menetapkan nilai kunci jawaban ke array currentJawaban pada indeks saat ini.

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
        Level4SoalHandler.instance.currentJawaban[Level4SoalHandler.instance.currentIndex] = Level4SoalHandler.instance.currentKunciLevel4[Level4SoalHandler.instance.currentIndex];

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
        }

        answerButtons[index].interactable = false;
    }

    public void JawabanSalahLevel3BKT(int index)
    {
        BKTAlgorithm.instance.currentJawaban = "Salah";

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
        }

        answerButtons[index].interactable = false;
    }

    public void JawabanBenarLevel3BKT(int index)
    {
        BKTAlgorithm.instance.currentJawaban = BKTAlgorithm.instance.currentKunciJawaban;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
        }

        answerButtons[index].interactable = false;
    }
}
