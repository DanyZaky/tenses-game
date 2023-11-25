using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        nameInput.text = "";

        if (PlayerPrefs.GetString("Nama") == "" || PlayerPrefs.GetString("Nama") == null)
        {
            loginPage.SetActive(true);
            menuPage.SetActive(false);
        }
        else
        {
            loginPage.SetActive(false);
            menuPage.SetActive(true);
        }
    }

    void Update()
    {
        if(nameInput.text == "")
        {
            submitNameButton.interactable = false;
        }
        else
        {
            submitNameButton.interactable = true;
        }

        if(PlayerPrefs.GetInt("Badge", 0) == 0)
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

        nameText.text = PlayerPrefs.GetString("Nama", "");
        bitangText.text = PlayerPrefs.GetInt("Bintang", 0).ToString();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void SubmitButton()
    {
        PlayerPrefs.SetString("Nama", nameInput.text);
    }
}
