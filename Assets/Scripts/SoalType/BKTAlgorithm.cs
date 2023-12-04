using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKTAlgorithm : MonoBehaviour
{
    public List<GameObject> easyQuestions;
    public List<GameObject> hardQuestions;

    public float knowledge = 0.2f; // Pengetahuan awal
    private float learnRate = 0.3f;
    private float guessRate = 0.1f;
    private float slipRate = 0.05f;


    private void Start()
    {
        // Memulai dengan menampilkan soal tipe mudah
        ShowRandomQuestion(easyQuestions);
    }

    private void ShowRandomQuestion(List<GameObject> questionList)
    {
        if (questionList.Count > 0)
        {
            // Memilih soal secara acak
            int randomIndex = Random.Range(0, questionList.Count);
            GameObject selectedQuestion = questionList[randomIndex];

            for (int i = 0; i < easyQuestions.Count; i++)
            {
                easyQuestions[i].SetActive(false);
            }

            for (int i = 0; i < hardQuestions.Count; i++)
            {
                hardQuestions[i].SetActive(false);
            }

            // Menampilkan soal
            selectedQuestion.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No questions available.");
        }
    }

    public void HandleAnswer(bool isCorrect)
    {
        // Memperbarui pengetahuan berdasarkan respons jawaban
        UpdateKnowledge(isCorrect);

        // Menentukan tipe soal berikutnya berdasarkan pengetahuan
        List<GameObject> nextQuestionList = (knowledge > 0.5f || !isCorrect) ? hardQuestions : easyQuestions;

        // Menampilkan soal dari tipe yang ditentukan
        ShowRandomQuestion(nextQuestionList);
    }

    private void UpdateKnowledge(bool isCorrect)
    {
        // Menghitung likelihood (kesesuaian) jawaban berdasarkan pengetahuan sebelumnya
        float pLearn = knowledge * (1 - slipRate) / ((knowledge * (1 - slipRate)) + ((1 - knowledge) * guessRate));

        // Menghitung likelihood (kesesuaian) jawaban berdasarkan ketidaktahuan sebelumnya
        float pGuess = (1 - knowledge) * guessRate / (((1 - knowledge) * guessRate) + (knowledge * slipRate));

        // Update pengetahuan berdasarkan jawaban siswa
        if (isCorrect)
        {
            // Jawaban benar
            knowledge = knowledge + (1 - knowledge) * pLearn;
        }
        else
        {
            // Jawaban salah
            knowledge = knowledge * (1 - pGuess);
        }

    }
}
