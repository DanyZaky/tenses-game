using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypePilgan : MonoBehaviour //code ini keseluruhan untuk cek jawaba dengan type soal pilgan
{
    public Button[] answerButtons; // Mendeklarasikan array tombol jawaban.

    public void JawabanSalah(int index) // method untuk jika jawaban salah di level 3
    {
        Level4SoalHandler.instance.currentJawaban[Level4SoalHandler.instance.currentIndex] = "Salah"; // Menetapkan nilai "Salah" ke array currentJawaban pada indeks saat ini.
        // Mengaktifkan kembali interaktabilitas semua tombol jawaban.
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
        }
        // Menonaktifkan interaktabilitas tombol jawaban yang dipilih.
        answerButtons[index].interactable = false; // fungsi ini berfungsi agar jawaban pilgan yang bisa dipilih tidak bisa di klik lagi
    }

    public void JawabanBenar(int index) // method untuk jika jawaban benar di level 3
    {
        Level4SoalHandler.instance.currentJawaban[Level4SoalHandler.instance.currentIndex] = Level4SoalHandler.instance.currentKunciLevel4[Level4SoalHandler.instance.currentIndex]; // Menetapkan nilai kunci jawaban ke array currentJawaban pada indeks saat ini.
        // Mengaktifkan kembali interaktabilitas semua tombol jawaban.
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
        }
        // Menonaktifkan interaktabilitas tombol jawaban yang dipilih.
        answerButtons[index].interactable = false; // fungsi ini berfungsi agar jawaban pilgan yang bisa dipilih tidak bisa di klik lagi
    }


    public void JawabanSalahLevel4(int index) // method untuk jika jawaban benar di level 4
    {
        Level4SoalHandler.instance.currentJawaban[Level4SoalHandler.instance.currentIndex] = "Salah"; // Menetapkan nilai "Salah" ke array currentJawaban pada indeks saat ini.
        // Mengaktifkan kembali interaktabilitas semua tombol jawaban.
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
        }
        // Menonaktifkan interaktabilitas tombol jawaban yang dipilih.
        answerButtons[index].interactable = false; // fungsi ini berfungsi agar jawaban pilgan yang bisa dipilih tidak bisa di klik lagi
    }

    public void JawabanBenarLevel4(int index) // method untuk jika jawaban benar di level 4
    {
        Level4SoalHandler.instance.currentJawaban[Level4SoalHandler.instance.currentIndex] = Level4SoalHandler.instance.currentKunciLevel4[Level4SoalHandler.instance.currentIndex]; //menetapkan jika nilai jawaban benar
        // Mengaktifkan kembali interaktabilitas semua tombol jawaban.
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
        }
        // Menonaktifkan interaktabilitas tombol jawaban yang dipilih.
        answerButtons[index].interactable = false; // fungsi ini berfungsi agar jawaban pilgan yang bisa dipilih tidak bisa di klik lagi
    }

    public void JawabanSalahLevel3BKT(int index)
    {
        BKTAlgorithm.instance.currentJawaban = "Salah"; // Menetapkan nilai "Salah" ke array currentJawaban pada indeks saat ini.
        // Mengaktifkan kembali interaktabilitas semua tombol jawaban.
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
        }
        // Menonaktifkan interaktabilitas tombol jawaban yang dipilih.
        answerButtons[index].interactable = false; // fungsi ini berfungsi agar jawaban pilgan yang bisa dipilih tidak bisa di klik lagi
    }

    public void JawabanBenarLevel3BKT(int index)
    {
        BKTAlgorithm.instance.currentJawaban = BKTAlgorithm.instance.currentKunciJawaban; //menetapkan jika jawaban benar
        // Mengaktifkan kembali interaktabilitas semua tombol jawaban.
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
        }
        // Menonaktifkan interaktabilitas tombol jawaban yang dipilih.
        answerButtons[index].interactable = false; // fungsi ini berfungsi agar jawaban pilgan yang bisa dipilih tidak bisa di klik lagi
    }
}
