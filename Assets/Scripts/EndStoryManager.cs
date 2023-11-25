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
        if(PlayerPrefs.GetInt("EndLock") == 0)
        {
            buttonEnd.SetActive(false);
        }
        else
        {
            buttonEnd.SetActive(true);
        }
    }

    public void OnClickDelay1()
    {
        StartCoroutine(delay1(2f));
    }

    public void OnClickDelay2() 
    {
        StartCoroutine(delay2(2f));
    }
    public void OnClickDelay3() 
    {
        StartCoroutine(delay3(2f));
    }

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

    private IEnumerator delay3(float time)
    {
        panelAkhir.SetActive(false);
        panelSoon.SetActive(true);

        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(0);
    }
}
