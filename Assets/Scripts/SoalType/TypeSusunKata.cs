using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeSusunKata : MonoBehaviour //code ini berfungsi untuk fungsi soal dengan type susun kata
{
    public TMP_InputField jawaban;  // TMP_InputField untuk input jawaban.
    public string[] words;  // Array string berisi kata-kata yang dapat dipilih.
    public GameObject[] wordObjects;  // Array GameObject yang merupakan representasi visual dari kata-kata.

    public void onClickWord(int index) // Metode yang dipanggil saat tombol kata-kata dipilih.
    {
        wordObjects[index].SetActive(false);  // Menonaktifkan objek visual untuk kata yang dipilih.
        jawaban.text += words[index] + " ";  // Menambahkan kata yang dipilih ke teks jawaban dengan spasi.
        BKTAlgorithm.instance.currentJawaban = jawaban.text.ToLower();  // Menetapkan nilai jawaban saat ini dari Level4SoalHandler dengan teks jawaban dalam huruf kecil.
    }

    public void ResetWords() // Metode untuk mereset pilihan kata-kata dan teks jawaban.
    {
        for(int i = 0; i < wordObjects.Length; i++) // Mengaktifkan kembali semua objek visual kata-kata.
        {
            wordObjects[i].SetActive(true);
        }

        jawaban.text = ""; // Mengosongkan teks jawaban.
    }
}
