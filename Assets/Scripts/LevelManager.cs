using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] buttonLevels;
    
    [Header("Level 1")]
    public GameObject[] level1;
    private int indexLevel1;
    public GameObject level1Panel;

    [Header("Level 2")]
    public GameObject[] level2;
    public AudioSource[] level2Audio;
    private int indexLevel2;
    public GameObject level2Panel;

    void Start()
    {
        // Menginisialisasi indeks level 1 dan level 2
        indexLevel1 = 0;
        indexLevel2 = 0;
    }

    private void Update()
    {
        //Kondisi untuk lock dan unlock button level 1-4
        // Kondisi untuk mengunci atau membuka tombol level 1-4 berdasarkan level yang telah dicapai
        if (PlayerPrefs.GetInt("Level", 1) == 1)
        {
            // Mengunci semua tombol level kecuali level 1
            for (int i = 0; i < buttonLevels.Length; i++)
            {
                buttonLevels[i].interactable = false;
            }
            buttonLevels[0].interactable = true;
        }
        else if(PlayerPrefs.GetInt("Level", 1) == 2)
        {
            // Mengunci semua tombol level kecuali level 1 dan 2
            for (int i = 0; i < buttonLevels.Length; i++)
            {
                buttonLevels[i].interactable = false;
            }
            buttonLevels[0].interactable = true;
            buttonLevels[1].interactable = true;
        }
        else if (PlayerPrefs.GetInt("Level", 1) == 3)
        {
            // Mengunci semua tombol level kecuali level 1, 2, dan 3
            for (int i = 0; i < buttonLevels.Length; i++)
            {
                buttonLevels[i].interactable = false;
            }
            buttonLevels[0].interactable = true;
            buttonLevels[1].interactable = true;
            buttonLevels[2].interactable = true;
        }
        else if (PlayerPrefs.GetInt("Level", 1) == 4)
        {
            // Membuka semua tombol level
            for (int i = 0; i < buttonLevels.Length; i++)
            {
                buttonLevels[i].interactable = true;
            }
        }
    }

    // Metode untuk tombol "Next" pada level 1
    public void NextLevel1Button() //Untuk fungsi next slide di level 1
    {
        if (indexLevel1 >= level1.Length - 1) // kondisi jika sudah di slide terakhir
        {
            Debug.Log("Finish Level 1");
            PlayerPrefs.SetInt("Level", 2);
            indexLevel1 = 0;
            for (int i = 0; i < level1.Length; i++)
            {
                level1[i].SetActive(false);
            }
            level1[0].SetActive(true);
            level1Panel.SetActive(false);
        }
        else // kondisi jika velum di slide terakhir
        {
            for (int i = 0; i < level1.Length; i++)
            {
                level1[i].SetActive(false);
            }
            indexLevel1++;
            level1[indexLevel1].SetActive(true);
            level2Panel.SetActive(false);
        }
    }

    // Metode untuk tombol "Next" pada level 2
    public void NextLevel2Button()
    {

        if (indexLevel2 >= level2.Length - 1) // kondisi jika sudah di slide terakhir
        {
            // Memberhentikan audio pada level 2
            for (int i2 = 0; i2 < level2Audio.Length; i2++)
            {
                level2Audio[i2].Stop();
            }
            Debug.Log("Finish Level 2");
            PlayerPrefs.SetInt("Level", 3);
            indexLevel2 = 0;
            for (int i = 0; i < level2.Length; i++)
            {
                level2[i].SetActive(false);
            }
            level2[0].SetActive(true);
            level2Panel.SetActive(false);
        }
        else // kondisi jika velum di slide terakhir
        {
            for (int i = 0; i < level2.Length; i++)
            {
                level2[i].SetActive(false);
            }
            indexLevel2++;
            if (indexLevel2 != 0 && indexLevel2 != 1)
            {
                // Memberhentikan semua audio sebelum memainkan audio level 2 yang baru
                for (int i2 = 0;i2 < level2Audio.Length;i2++)
                {
                    level2Audio[i2].Stop();
                }
                level2Audio[indexLevel2].Play(); // melakukan play audio sesuai slide
            }
            level2[indexLevel2].SetActive(true);
        }
    }

    // Metode untuk tombol "Home"
    public void HomeButton()
    {
        SceneManager.LoadScene(0); //load ke scene utama atau menu utama
    }
}

