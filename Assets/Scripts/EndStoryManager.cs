using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndStoryManager : MonoBehaviour
{
    public GameObject panelbeforeBuka, panelTua, panelPertama;
    public GameObject panelBeforePeti, panelPetiClose, panelPetiOpen, panelAfterPeti;
    public GameObject panelAkhir, panelSoon;

    public GameObject buttonEnd;

    private void Update()
    {
        // Memeriksa status dari PlayerPrefs untuk menentukan apakah tombol "End" aktif atau tidak
        if (PlayerPrefs.GetInt("EndLock") == 0)
        {
            buttonEnd.SetActive(false);
        }
        else
        {
            buttonEnd.SetActive(true);
        }
    }

    // Metode untuk memulai penundaan pertama
    public void OnClickDelay1()
    {
        StartCoroutine(delay1(2f));
    }

    // Metode untuk memulai penundaan kedua
    public void OnClickDelay2() 
    {
        StartCoroutine(delay2(2f));
    }

    // Metode untuk memulai penundaan ketiga
    public void OnClickDelay3() 
    {
        StartCoroutine(delay3(2f));
    }

    // Coroutine untuk penundaan pertama
    private IEnumerator delay1(float time)
    {
        panelbeforeBuka.SetActive(true);
        panelTua.SetActive(false);
        panelPertama.SetActive(false);
        yield return new WaitForSeconds(time);

        panelbeforeBuka.SetActive(false);
        panelTua.SetActive(true);
        panelPertama.SetActive(false);
        yield return new WaitForSeconds(time);

        panelbeforeBuka.SetActive(false);
        panelTua.SetActive(false);
        panelPertama.SetActive(true);
        yield return new WaitForSeconds(time);
    }

    // Coroutine untuk penundaan kedua
    private IEnumerator delay2(float time)
    {
        panelBeforePeti.SetActive(false);
        panelPetiClose.SetActive(true);
        panelPetiOpen.SetActive(false);
        panelAfterPeti.SetActive(false);
        yield return new WaitForSeconds(time);

        panelBeforePeti.SetActive(false);
        panelPetiClose.SetActive(false);
        panelPetiOpen.SetActive(true);
        panelAfterPeti.SetActive(false);
        yield return new WaitForSeconds(time);

        panelBeforePeti.SetActive(false);
        panelPetiClose.SetActive(false);
        panelPetiOpen.SetActive(false);
        panelAfterPeti.SetActive(true);
    }

    // Coroutine untuk penundaan ketiga
    private IEnumerator delay3(float time)
    {
        panelAkhir.SetActive(false);
        panelSoon.SetActive(true);

        yield return new WaitForSeconds(time);

        // Memuat kembali scene dengan indeks 0 atau menu utama
        SceneManager.LoadScene(0);
    }
}
