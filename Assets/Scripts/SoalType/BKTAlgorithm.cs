using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BKTAlgorithm : MonoBehaviour
{
    // Pola Singleton
    public static BKTAlgorithm instance;

    private void Awake()
    {
        instance = this;
    }
    // Variabel untuk jawaban saat ini, objek hasil benar dan salah, kunci jawaban, dan tombol selanjutnya
    public string currentJawaban, currentKunciJawaban;
    public GameObject correctResult, uncorrectResult;
    public string[] kunciJawaban;
    public Button nextButton;

    // Daftar untuk menyimpan angka acak yang dihasilkan untuk tingkat kesulitan yang berbeda
    [SerializeField] private List<int> generatedNumbersEasy = new List<int>();
    [SerializeField] private List<int> generatedNumbersMed = new List<int>();
    [SerializeField] private List<int> generatedNumbersHard = new List<int>();
    [SerializeField] private GameObject selectedQuestion;

    // Daftar untuk menyimpan jenis-jenis pertanyaan yang berbeda untuk ditampilkan
    [Header("Soal Display")]
    public List<GameObject> easyQuestions;
    public List<GameObject> mediumQuestions;
    public List<GameObject> hardQuestions;

    // Daftar untuk menyimpan kunci jawaban untuk jenis-jenis pertanyaan
    [Header("Kunci Jawaban")]
    public List<string> easyQuestionsKunci;
    public List<string> mediumQuestionsKunci;
    public List<string> hardQuestionsKunci;

    // Variabel untuk parameter algoritma BKT
    [Header("BKT")]
    public int totalSoal;
    public float knowledge = 0.2f; // Pengetahuan awal
    private float learnRate = 0.3f;
    private float guessRate = 0.1f;
    private float slipRate = 0.05f;

    // Elemem-elemen untuk kondisi menang/kalah
    [Header("Win/Lose Condition")]
    public GameObject winPanel;
    public TextMeshProUGUI bktText;
    public TextMeshProUGUI kesulitanText;
    public GameObject[] health;
    public int currentHealth;
    public GameObject losePanel;

    private void Start()
    {
        // Menginisialisasi jumlah total pertanyaan dan kesehatan saat ini
        totalSoal = 1;
        currentHealth = 3;

        // Mengosongkan daftar angka yang dihasilkan tiap tingkat kesulitan
        generatedNumbersEasy.Clear();
        generatedNumbersMed.Clear();
        generatedNumbersHard.Clear();
    }

    private void Update()
    {
        // Memeriksa apakah jawaban kosong atau null untuk mengaktifkan/menonaktifkan tombol selanjutnya
        if (currentJawaban == null || currentJawaban == "")
        {
            nextButton.interactable = false;
        }
        else
        {
            nextButton.interactable = true;
        }

        // Memperbarui UI berdasarkan health saat ini
        if (currentHealth >= 3)
        {
            for (int i = 0; i < health.Length; i++)
            {
                health[i].SetActive(true);
            }
        }
        else if(currentHealth == 2)
        {
            for (int i = 0; i < health.Length; i++)
            {
                health[i].SetActive(true);
            }

            health[2].SetActive(false);
        }
        else if (currentHealth == 1)
        {
            for (int i = 0; i < health.Length; i++)
            {
                health[i].SetActive(true);
            }

            health[2].SetActive(false);
            health[1].SetActive(false);
        }
        else if(currentHealth <= 0)
        {
            for (int i = 0; i < health.Length; i++)
            {
                health[i].SetActive(false);
            }
        }
    }

    // Metode untuk memulai level 3 BKT
    public void StartBKTLevel3()
    {
        ShowRandomQuestion(mediumQuestions);
    }

    // Metode untuk menampilkan pertanyaan acak dari daftar yang diberikan
    private void ShowRandomQuestion(List<GameObject> questionList)
    {
        // Memeriksa apakah ada pertanyaan dalam daftar
        if (questionList.Count > 0)
        {
            // Memilih soal secara acak
            string tipeSoalString = "";

            if (questionList == easyQuestions)
            {
                int randomIndex = GetUniqueRandomNumber(generatedNumbersEasy, easyQuestions); //memilih random soal 
                selectedQuestion = questionList[randomIndex];
                currentKunciJawaban = easyQuestionsKunci[randomIndex];
                tipeSoalString = "Mudah";
            }
            else if(questionList == mediumQuestions)
            {
                int randomIndex = GetUniqueRandomNumber(generatedNumbersMed, mediumQuestions); //memilih random soal 
                selectedQuestion = questionList[randomIndex];
                currentKunciJawaban = mediumQuestionsKunci[randomIndex];
                tipeSoalString = "Sedang";
            }
            else if(questionList == hardQuestions)
            {
                int randomIndex = GetUniqueRandomNumber(generatedNumbersHard, hardQuestions); //memilih random soal 
                selectedQuestion = questionList[randomIndex];
                currentKunciJawaban = hardQuestionsKunci[randomIndex];
                tipeSoalString = "Sulit";
            }

            for (int i = 0; i < easyQuestions.Count; i++)
            {
                easyQuestions[i].SetActive(false);
            }
            for (int i = 0; i < mediumQuestions.Count; i++)
            {
                mediumQuestions[i].SetActive(false);
            }
            for (int i = 0; i < hardQuestions.Count; i++)
            {
                hardQuestions[i].SetActive(false);
            }

            // Menampilkan pertanyaan yang dipilih
            selectedQuestion.SetActive(true);
            // Mengatur ulang jawaban saat ini
            currentJawaban = "";

            // Memperbarui UI dengan tingkat kesulitan dan pengetahuan
            kesulitanText.text = kesulitanText.text + "\n" + tipeSoalString;
            bktText.text = bktText.text + "\n" + knowledge.ToString("0.000");
        }
        else
        {
            Debug.LogWarning("No questions available.");
        }
    }

    // Metode untuk mendapatkan nomor acak unik dari sebuah list soal dengan tipe kesulitan tertentu
    int GetUniqueRandomNumber(List<int> generatedNumbers, List<GameObject> questionList)
    {
        int randomNumber;
        do
        {
            randomNumber = Random.Range(1, questionList.Count);
        } while (generatedNumbers.Contains(randomNumber));

        generatedNumbers.Add(randomNumber);
        return randomNumber;
    }

    // Metode untuk memeriksa jawaban dan memperbarui status permainan
    public void CheckAnswer()
    {
        // Menambahkan total pertanyaan
        totalSoal++;
        // Memeriksa apakah jawaban benar
        bool isCorrect;

        if (currentJawaban.ToLower().TrimEnd() == currentKunciJawaban.ToLower().TrimEnd())
        {
            isCorrect = true;
            // Menampilkan hasil benar dan memperbarui health
            correctResult.SetActive(true);
            if(currentHealth < 3)
            {
                currentHealth++;
            }
        }
        else
        {
            isCorrect = false;
            // Menampilkan hasil salah dan memperbarui health
            uncorrectResult.SetActive(true);
            currentHealth--;
        }

        // Memperbarui pengetahuan berdasarkan respons jawaban
        UpdateKnowledge(isCorrect);

        // Menentukan tipe soal berikutnya berdasarkan pengetahuan
        List<GameObject> nextQuestionList;

        if (knowledge > 0.5f)
        {
            nextQuestionList = hardQuestions;
        }
        else if (knowledge > 0.2f)
        {
            nextQuestionList = mediumQuestions;
        }
        else
        {
            nextQuestionList = easyQuestions;
        }

        // Menampilkan soal dari tipe yang ditentukan
        ShowRandomQuestion(nextQuestionList);
    }

    private void UpdateKnowledge(bool isCorrect)
    {
        // Menghitung probabilitas
        float pLearn = knowledge * (1 - slipRate) / ((knowledge * (1 - slipRate)) + ((1 - knowledge) * guessRate));
        float pGuess = (1 - knowledge) * guessRate / (((1 - knowledge) * guessRate) + (knowledge * slipRate));

        // Memperbarui pengetahuan
        if (isCorrect) //perbarui jika benar
        {
            knowledge = knowledge + (1 - knowledge) * pLearn;
        }
        else // perbarui jika salah
        {
            knowledge = knowledge * (1 - pGuess);
        }
    }

    public void GameOver(int index) //update progress ke level 4
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if(index == 10)
        {
            PlayerPrefs.SetInt("Level", 4);
        }
    }

    // Metode untuk memeriksa status permainan secara keseluruhan
    public void CheckSoal()
    {
        // Memeriksa kondisi menang/kalah dan menampilkan panel yang sesuai
        if (currentHealth <= 0)
        {
            losePanel.SetActive(true);
        }
        else
        {
            if (totalSoal >= 10)
            {
                winPanel.SetActive(true);
            }
            else
            {
                winPanel.SetActive(false);
            }
        }
    }
}
