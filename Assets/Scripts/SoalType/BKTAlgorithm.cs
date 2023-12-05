using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BKTAlgorithm : MonoBehaviour
{
    public static BKTAlgorithm instance;

    private void Awake()
    {
        instance = this;
    }

    public string currentJawaban, currentKunciJawaban;
    public GameObject correctResult, uncorrectResult;
    public string[] kunciJawaban;
    public Button nextButton;

    [Header("Soal Display")]
    public List<GameObject> easyQuestions;
    public List<GameObject> mediumQuestions;
    public List<GameObject> hardQuestions;

    [Header("Kunci Jawaban")]
    public List<string> easyQuestionsKunci;
    public List<string> mediumQuestionsKunci;
    public List<string> hardQuestionsKunci;

    [Header("BKT")]
    public int totalSoal;
    public float knowledge = 0.2f; // Pengetahuan awal
    private float learnRate = 0.3f;
    private float guessRate = 0.1f;
    private float slipRate = 0.05f;

    private void Start()
    {
        totalSoal = 1;
    }

    private void Update()
    {
        if(currentJawaban == null || currentJawaban == "")
        {
            nextButton.interactable = false;
        }
        else
        {
            nextButton.interactable = true;
        }
    }

    public void StartBKTLevel3()
    {
        ShowRandomQuestion(mediumQuestions);
    }

    private void ShowRandomQuestion(List<GameObject> questionList)
    {
        if (questionList.Count > 0)
        {
            // Memilih soal secara acak
            int randomIndex = Random.Range(0, questionList.Count);
            GameObject selectedQuestion = questionList[randomIndex];

            if(questionList == easyQuestions)
            {
                currentKunciJawaban = easyQuestionsKunci[randomIndex];
            }
            else if(questionList == mediumQuestions)
            {
                currentKunciJawaban = mediumQuestionsKunci[randomIndex];
            }
            else if(questionList == hardQuestions)
            {
                currentKunciJawaban = hardQuestionsKunci[randomIndex];
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

            // Menampilkan soal
            selectedQuestion.SetActive(true);

            currentJawaban = "";
        }
        else
        {
            Debug.LogWarning("No questions available.");
        }
    }

    public void CheckAnswer()
    {
        totalSoal++;

        bool isCorrect;

        if (currentJawaban.ToLower().TrimEnd() == currentKunciJawaban.ToLower().TrimEnd())
        {
            isCorrect = true;
            correctResult.SetActive(true);
        }
        else
        {
            isCorrect = false;
            uncorrectResult.SetActive(true);
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
        float pLearn = knowledge * (1 - slipRate) / ((knowledge * (1 - slipRate)) + ((1 - knowledge) * guessRate));
        float pGuess = (1 - knowledge) * guessRate / (((1 - knowledge) * guessRate) + (knowledge * slipRate));

        if (isCorrect)
        {
            knowledge = knowledge + (1 - knowledge) * pLearn;
        }
        else
        {
            knowledge = knowledge * (1 - pGuess);
        }
    }
}
