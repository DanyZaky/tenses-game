using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeEssay : MonoBehaviour
{
    public TMP_InputField jawabanInput; // Mendeklarasikan variabel public TMP_InputField bernama jawabanInput.

    public void Jawaban()
    {
        Level4SoalHandler.instance.currentJawaban[Level4SoalHandler.instance.currentIndex] = jawabanInput.text.ToLower(); // Mengakses array currentJawaban di SoalHandler.instance dan menetapkan teks dalam huruf kecil dari jawabanInput ke indeks saat ini.

    }

    public void JawabanLevel4()
    {
        Level4SoalHandler.instance.currentJawaban[Level4SoalHandler.instance.currentIndex] = jawabanInput.text.ToLower(); // Mengakses array currentJawaban di Level4SoalHandler.instance dan menetapkan teks dalam huruf kecil dari jawabanInput ke indeks saat ini.
    }

    public void JawabanLevel3BKT()
    {
        BKTAlgorithm.instance.currentJawaban = jawabanInput.text.ToLower();
    }
}
