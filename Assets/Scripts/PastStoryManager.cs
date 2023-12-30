using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * code ini hanya mengatur keseluruhan di bagian Past Story dan hanya berfungsi sebagai slides next yang memiliki delay
 * code ini tidak tersambung dengan code lainnya
 */

public class PastStoryManager : MonoBehaviour
{
    public GameObject[] slides;

    private void Start()
    {
        // Memulai coroutine "starting" saat objek diaktifkan
        StartCoroutine(starting());
    }

    private IEnumerator starting() // membuat fungsi delay tiap slide di Past Story
    {
        // Mengatur semua slide menjadi tidak aktif pada awalnya
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].gameObject.SetActive(false);
        }
        // Mengatur slide pertama menjadi aktif
        slides[0].gameObject.SetActive(true);
        // Menunda eksekusi selama 2 detik
        yield return new WaitForSeconds(2f);
        // Kembali mengatur semua slide menjadi tidak aktif
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].gameObject.SetActive(false);
        }
        // Mengatur slide kedua menjadi aktif setelah penundaan
        slides[1].gameObject.SetActive(true);
    }

    // Metode untuk kembali ke layar utama
    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }

    // Metode untuk memulai permainan
    public void GameplayButton()
    {
        SceneManager.LoadScene(2);
    }
}
