using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * code ini mengatur mengenai data dari user, baik itu dari nama, health, badge, dll
 * code ini tidak tersambung dengan code lainnya, tetapi berhubungan dengan code level4handler dan BKTAlgorithm dalam pengambilan data
 */

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TMP_InputField nameInput;
    public Button submitNameButton;

    public TextMeshProUGUI bitangText;

    public Image badgeImage;
    public TextMeshProUGUI badgeText;
    public Sprite[] badgeSprite;

    [Header("Login")]
    public GameObject loginPage, menuPage;

    void Start()
    {
        // Mengatur teks input nama menjadi kosong
        nameInput.text = "";

        // Memeriksa apakah nama sudah tersimpan di PlayerPrefs
        if (PlayerPrefs.GetString("Nama") == "" || PlayerPrefs.GetString("Nama") == null)
        {
            // Jika belum, menampilkan halaman login dan menyembunyikan halaman menu
            loginPage.SetActive(true);
            menuPage.SetActive(false);
        }
        else         // Jika sudah, menyembunyikan halaman login dan menampilkan halaman menu
        {
            loginPage.SetActive(false);
            menuPage.SetActive(true);
        }
    }

    void Update()
    {
        // Menonaktifkan tombol submit jika teks input nama kosong
        if (nameInput.text == "")
        {
            submitNameButton.interactable = false;
        }
        else
        {
            submitNameButton.interactable = true;
        }

        // Menyesuaikan tampilan badge berdasarkan level badge yang dimiliki pemain
        if (PlayerPrefs.GetInt("Badge", 0) == 0)
        {
            badgeImage.gameObject.SetActive(false);
            badgeText.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Badge", 0) == 1)
        {
            badgeImage.gameObject.SetActive(true);
            badgeText.gameObject.SetActive(true);

            badgeImage.sprite = badgeSprite[0];
            badgeText.text = "Tingkat 1";
        }
        else if (PlayerPrefs.GetInt("Badge", 0) == 2)
        {
            badgeImage.gameObject.SetActive(true);
            badgeText.gameObject.SetActive(true);

            badgeImage.sprite = badgeSprite[1];
            badgeText.text = "Tingkat 2";
        }
        else if (PlayerPrefs.GetInt("Badge", 0) == 3)
        {
            badgeImage.gameObject.SetActive(true);
            badgeText.gameObject.SetActive(true);

            badgeImage.sprite = badgeSprite[2];
            badgeText.text = "Tingkat 3";
        }

        // Menampilkan nama dan jumlah bintang pada UI
        nameText.text = PlayerPrefs.GetString("Nama", "");
        bitangText.text = PlayerPrefs.GetInt("Bintang", 0).ToString();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);     // Memuat scene permainan dengan indeks 1
    }

    public void SubmitButton()
    {
        PlayerPrefs.SetString("Nama", nameInput.text);     // Menyimpan teks input nama ke dalam PlayerPrefs
    }
}
