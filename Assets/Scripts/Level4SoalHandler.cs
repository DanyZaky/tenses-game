using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level4SoalHandler : MonoBehaviour
{
    public static Level4SoalHandler  instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject nextButton, prevButton, finishButton;

    public GameObject[] soalDisplay;
    public string[] kunciLevel3;
    public string[] currentKunciLevel3;
    public string[] currentJawaban;
    public int[] soalIndex;
    public int currentIndex;

    public int correct, wrong;

    [Header("Finish")]
    public TextMeshProUGUI resultText;
    public Image gelarImage;
    public GameObject[] bintangs;
    public TextMeshProUGUI totalbintangs;
    public Sprite[] gelars;

    [Header("Timer")]
    public TextMeshProUGUI timerText;
    public Image backgroundTimer;
    public float totalTime = 600f;
    public bool isTImeRunning;
    public float currentTime;
    public GameObject gameOver;


    void Start()
    {
        soalIndex = GenerateRandomIntArray(10, 0, 44);

        for (int i = 0; i < currentKunciLevel3.Length; i++)
        {
            currentKunciLevel3[i] = kunciLevel3[soalIndex[i]];
        }

        currentIndex = 0;
        for (int i = 0; i < soalDisplay.Length; i++)
        {
            soalDisplay[i].SetActive(false);
        }
        soalDisplay[soalIndex[currentIndex]].SetActive(true);

        isTImeRunning = false;
        currentTime = totalTime;
        backgroundTimer.color = new Color32(255, 228, 181, 255);
        timerText.color = Color.black;
        gameOver.SetActive(false);
    }

    private void Update()
    {
        if (currentIndex <= 0)
        {
            prevButton.SetActive(false);
            nextButton.SetActive(true);
            finishButton.SetActive(false);
        }
        else if (currentIndex >= 9)
        {
            prevButton.SetActive(true);
            nextButton.SetActive(false);
            finishButton.SetActive(true);
        }
        else
        {
            prevButton.SetActive(true);
            nextButton.SetActive(true);
            finishButton.SetActive(false);
        }

        if (CheckArrayValues(currentJawaban))
        {
            finishButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            finishButton.GetComponent<Button>().interactable = false;
        }

        Debug.Log(CheckArrayValues(currentJawaban));


        if(isTImeRunning)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerText();

                if(currentTime > 60)
                {
                    backgroundTimer.color = new Color32(255, 228, 181, 255);
                    timerText.color = Color.black;
                }
                else
                {
                    backgroundTimer.color = Color.red;
                    timerText.color = Color.white;
                }
            }
            else
            {
                gameOver.SetActive(true);
                isTImeRunning = false;
                currentTime = totalTime;
                Debug.Log("Waktu telah habis!");
            }
        }
        else
        {
            currentTime = totalTime;
        }
    }

    void UpdateTimerText()
    {
        // Menghitung menit dan detik
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Mengatur teks timer dengan format 00:00
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    int[] GenerateRandomIntArray(int length, int minValue, int maxValue)
    {
        if (length > (maxValue - minValue + 1))
        {
            Debug.LogError("Panjang array tidak valid untuk rentang nilai yang diberikan.");
            return null;
        }

        List<int> values = new List<int>();
        for (int i = minValue; i <= maxValue; i++)
        {
            values.Add(i);
        }

        int[] randomArray = new int[length];
        for (int i = 0; i < length; i++)
        {
            int randomIndex = Random.Range(0, values.Count);
            randomArray[i] = values[randomIndex];
            values.RemoveAt(randomIndex);
        }

        return randomArray;
    }

    public void NextSoal()
    {
        currentIndex++;
        for (int i = 0; i < soalDisplay.Length; i++)
        {
            soalDisplay[i].SetActive(false);
        }
        soalDisplay[soalIndex[currentIndex]].SetActive(true);
    }

    public void PrevSoal()
    {
        currentIndex--;
        for (int i = 0; i < soalDisplay.Length; i++)
        {
            soalDisplay[i].SetActive(false);
        }
        soalDisplay[soalIndex[currentIndex]].SetActive(true);
    }

    public void FinishButton()
    {
        PlayerPrefs.SetInt("EndLock", 1);
        isTImeRunning = false;
        correct = 0;
        wrong = 0;
        
        //PlayerPrefs.SetInt("Level", 5);
        for (int i = 0;i < currentJawaban.Length;i++)
        {
            if (currentJawaban[i].ToLower().TrimEnd() == currentKunciLevel3[i].ToLower().TrimEnd())
            {
                correct++;
            }
        }

        wrong = 10 - correct;

        Debug.Log("Benar : " + correct +  "Salah : " + wrong);

        resultText.text = "Right : " + correct + "\nWrong : " + wrong;
        if(correct <= 3)
        {
            gelarImage.sprite = gelars[0];
            PlayerPrefs.SetInt("Badge", 3);
        }
        else if(correct <= 6 && correct > 3) 
        {
            gelarImage.sprite = gelars[1];
            PlayerPrefs.SetInt("Badge", 2);
        }
        else if (correct <= 10 && correct > 6)
        {
            gelarImage.sprite = gelars[2];
            PlayerPrefs.SetInt("Badge", 1);
        }
        else
        {
            gelarImage.sprite = gelars[3];
            PlayerPrefs.SetInt("Badge", 0);
        }

        for (int i = 0; i < bintangs.Length; i++)
        {
            bintangs[i].SetActive(false);
        }

        for (int i = 0; i < correct; i++)
        {
            bintangs[i].SetActive(true);
        }

        if(correct <= 0)
        {
            totalbintangs.text = "You don't get a Star!";
        }
        else
        {
            totalbintangs.text = correct.ToString();
        }
        
        int currentBintang = PlayerPrefs.GetInt("Bintang", 0) + correct;
        PlayerPrefs.SetInt("Bintang", currentBintang);

    }

    bool CheckArrayValues(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (string.IsNullOrEmpty(array[i]) || array[i] == "")
            {
                return false;
            }
        }
        return true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartLevel4()
    {
        isTImeRunning = true;
    }
}
