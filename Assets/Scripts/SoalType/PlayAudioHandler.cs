using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioHandler : MonoBehaviour // code ini untuk melakukan play audio pada soal yang ada audio nya
{
    public void PlayThisAudio()
    {
        gameObject.GetComponent<AudioSource>().Play(); //Play audio tiap soal.

    }
}
