using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PastStoryManager : MonoBehaviour
{
    public GameObject[] slides;

    private void Start()
    {
        StartCoroutine(starting());
    }

    private IEnumerator starting()
    {
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].gameObject.SetActive(false);
        }
        slides[0].gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].gameObject.SetActive(false);
        }
        slides[1].gameObject.SetActive(true);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }

    public void GameplayButton()
    {
        SceneManager.LoadScene(2);
    }
}
