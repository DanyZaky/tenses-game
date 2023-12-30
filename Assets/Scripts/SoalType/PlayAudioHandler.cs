using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Code ini khusus untuk play audio pada soal atau slide yang memiliki audio
 * Code ini tidak tersambung ke code lainnya, jadi hanya berhubungan dengan soal yang memiliki soal audio
 */

public class PlayAudioHandler : MonoBehaviour // code ini untuk melakukan play audio pada soal yang ada audio nya
{
    public void PlayThisAudio()
    {
        gameObject.GetComponent<AudioSource>().Play(); //Play audio tiap soal.

    }
}
