using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
Code ini mengatur keseluruhan Soal dengn type essay yang berfungsi menyimpan inputan jawaban dari Input user ke dalam variable currentJawaban
Code ini tersambung ke code Level4SoalHandler (untuk mengatur currentJawaban di level 4) dan di code BKTAlgoritm (untuk mengatur currentJawaban di level 3)
 */

public class TypeEssay : MonoBehaviour //code ini keseluruh dipakai untuk fungsi soal type essay
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
        BKTAlgorithm.instance.currentJawaban = jawabanInput.text.ToLower(); //memasukkan hasil inputan ke dalam varible currenJawaban yang nantinya digunakan untuk cek soal jawaban
    }
}
