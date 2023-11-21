using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TMP_InputField nameInput;
    public Button submitNameButton;

    void Start()
    {
        nameInput.text = "";
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

        nameText.text = nameInput.text;
    }
}
